using System.Threading;
using System.Threading.Tasks;
using AmmBot.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using AmmBot.Core.Json.Models;
using System.Text.Json;

namespace AmmBot.Core.Extensions
{
    /// <summary>
    /// Представляет расширения для работы с сообщениями.
    /// </summary>
    public static class MessagesExtension
    {
        /// <summary>
        /// Генератор случайных значений.
        /// </summary>
        private static Lazy<Random> s_Random = new Lazy<Random>(() => new Random());

        /// <summary>
        /// Асинхронно отправляет сообщение.
        /// </summary>
        /// <param name="bot">Бот.</param>
        /// <param name="peerId">Получатель.</param>
        /// <param name="randomId">Случайное число (предотвращает повторную отправку).</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="stickerId">Идентификатор стикера.</param>
        /// <param name="dontParseLinks">true, если не нужно преобразовывать ссылки в подложки.</param>
        /// <param name="disableMentions">true, если не нужно оповещать пользователя о теге в сообщении.</param>
        /// <param name="attachment">Вложения.</param>
        /// <param name="forward">Пересланные сообщения.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        public static async ValueTask<long> SendMessage(this IVkBot bot,
            long peerId,
            int randomId,
            string message = default,
            long stickerId = default,
            bool dontParseLinks = true,
            bool disableMentions = true,
            string[] attachment = default,
            Forward forward = default,
            CancellationToken cancellationToken = default)
        {
            var args = new Dictionary<string, string>
            {
                ["peer_id"] = peerId.ToString(),
                ["random_id"] = randomId.ToString(),
                ["dont_parse_links"] = (dontParseLinks ? 1 : 0).ToString(),
                ["disable_mentions"] = (disableMentions ? 1 : 0).ToString()
            };

            if (!string.IsNullOrEmpty(message))
                args.Add("message", message);

            if (stickerId != default)
                args.Add("sticker_id", stickerId.ToString());

            if (attachment?.Any() ?? false)
                args.Add("attachment", string.Join(",", attachment));

            if (forward is not null)
                args.Add("forward", WebUtility.UrlEncode(JsonSerializer.Serialize(forward)));
            
            return await bot.ExecMethodAsync<long>("messages.send", args, cancellationToken);
        }
        
        /// <summary>
        /// Генерирует случайный идентификатор. 
        /// </summary>
        /// <returns>Случайное число</returns>
        public static int GenerateRandom()
        {
            return s_Random.Value.Next();
        }
    }
}