using System;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AmmBot.HelloProvider.Interfaces;
using AmmBot.Core.Interfaces;
using AmmBot.Core.Json.Models;
using AmmBot.Core.Extensions;

namespace AmmBot.HelloProvider
{
    public class AmmHelloUserStrategy : IHelloUserStrategy
    {
        private static readonly string[] s_Emojies;

        private readonly Random _random;

        static AmmHelloUserStrategy()
        {
            s_Emojies = new string[]
            {
                "&#128530;",
                "&#128532;",
                "&#128546;",
                "&#128557;",
                "&#128553;",
                "&#128560;",
                "&#128562;",
                "&#128565;",
                "&#128543;",
                "&#128554;",
                "&#128555;",
                "&#128549;",
                "&#128534;",
                "&#128547;",
                "&#128542;",
                "&#128531;",
                "&#128148;",
                "&#128575;",
                "&#128128;",
                "&#12349;",
                "&#9904;",
                "&#9785;",
                "&#9760;",
                "&#128577;",
                "&#128580;",
                "&#129296;",
                "&#129298;",
                "&#129301;"
            }.Select(x => WebUtility.UrlEncode(x)).ToArray();;
        }

        public AmmHelloUserStrategy()
        {
            _random = new Random();
        }

        private string GetRandomEmoji()
        {
            return s_Emojies[_random.Next(0, s_Emojies.Length)];
        }

        public ValueTask<long> SayHelloAsync(IVkBot bot, long peerId, User user, CancellationToken cancellationToken = default)
        {
            string message = $"{ user.GetUserTaggedText(user.FirstName) }, привет! Как твои дела? Почему ПММ? { GetRandomEmoji() }";
            return bot.SendMessage(
                    peerId: peerId,
                    randomId: MessagesExtension.GenerateRandom(),
                    message: message,
                    stickerId: default,
                    dontParseLinks: true,
                    disableMentions: true,
                    attachment: null,
                    forward: null,
                    cancellationToken: cancellationToken);
        }
    }
}
