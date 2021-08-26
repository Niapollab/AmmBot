using System;
using System.Threading;
using System.Threading.Tasks;
using AmmBot.Core.Extensions;
using AmmBot.Core.Interfaces;
using AmmBot.Core.LongPoll;
using AmmBot.HelloProvider.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AmmBot.Core.Json.Models;
using System.Linq;

namespace AmmBot.Service
{
    internal sealed class VkBotService : BackgroundService
    {
        private readonly IVkBot _bot;

        private readonly ILogger<VkBotService> _logger;

        private readonly IHelloUserStrategy _helloUserStrategy;

        private readonly VkBotOptions _options;

        public VkBotService(IOptions<VkBotOptions> options, ILogger<VkBotService> logger, IHelloUserStrategy helloUserStrategy, IVkBot bot)
        {
            _options = options.Value;
            _logger = logger;
            _helloUserStrategy = helloUserStrategy;
            _bot = bot;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Process started Long poll connection.");
                await ReceiveUpdatesAsync(stoppingToken);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Long poll connection process stopped.");
            }
        }

        private async Task ReceiveUpdatesAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    var events = _bot.LongPoll(_options.Id, _options.LongPollWait, 3, cancellationToken);
                    await foreach (UpdateData item in events)
                    {
                        ValueTask handler = HandleUpdate(item, cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException)
                        throw;
                    else
                        _logger.LogError(0, ex, "An error occurred while handling the event.");
                    await Task.Delay(_options.TimeoutOfRetry, cancellationToken);
                }
            }
        }

        private async ValueTask HandleUpdate(UpdateData updateData, CancellationToken cancellationToken = default)
        {
            if (updateData.Type != "message_new")
                return;

            Message message = updateData.Object as Message;
            _logger.LogInformation("Handled new message from peer_id = {0}, from_id = {1}.", message.PeerId, message.FromId);

            if (IsNewMemberInConversationMessage(message))
            {
                _logger.LogInformation("[{}, {}] Founded new conversation member. Send hello message.", message.PeerId, message.FromId);
                await SendHelloAsync(message, cancellationToken);
            }
            else if (IsReplyToBotMessage(message) && ReplyRowLessTwo(message))
            {
                _logger.LogInformation("[{}, {}] Founded answer to bot message. Send sticker.", message.PeerId, message.FromId);
                await ReplyToHelloMessage(message, cancellationToken);
            }
        }

        private async ValueTask ReplyToHelloMessage(Message message, CancellationToken cancellationToken)
        {
            await _bot.SendMessage(
                peerId: message.PeerId,
                randomId: MessagesExtension.GenerateRandom(),
                message: null,
                stickerId: 14084,
                dontParseLinks: true,
                disableMentions: true,
                attachment: null,
                forward: new Forward
                {
                    PeerId = message.PeerId,
                    ConversationMessageIds = new long[] {
                        message.ConversationMessageId
                    },
                    IsReply = true
                },
                cancellationToken: cancellationToken);
        }

        private async ValueTask SendHelloAsync(Message message, CancellationToken cancellationToken)
        {
            User user = (await _bot.GetUserAsync(new[] { message.Action.MemberId.ToString() }, "nom", null, cancellationToken)).FirstOrDefault();
            if (user is not null)
                await _helloUserStrategy.SayHelloAsync(_bot, message.PeerId, user, cancellationToken);
        }

        private bool IsNewMemberInConversationMessage(Message message)
        {
            return message?.Action?.Type?.StartsWith("chat_invite_user") ?? false;
        }

        private bool IsReplyToBotMessage(Message message)
        {
            var lastForwardedMessage = message.ForwardedMessages.FirstOrDefault();

            if (lastForwardedMessage is null)
                return false;

            return lastForwardedMessage.FromId == -_options.Id;
        }

        private bool ReplyRowLessTwo(Message message)
        {
            var lastForwardedMessage = message.ForwardedMessages.FirstOrDefault();
            return lastForwardedMessage is not null && !(lastForwardedMessage.ForwardedMessages?.Any() ?? false);
        }
    }
}