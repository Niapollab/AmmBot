using System;
using System.Threading.Tasks;
using AmmBot.Core.Interfaces;
using System.Threading;
using System.Collections.Generic;
using AmmBot.Core.Json.Models;
using System.Linq;

namespace AmmBot.Core.Extensions
{
    /// <summary>
    /// Представляет расширения для работы с пользователями.
    /// </summary>
    public static class UsersExtensions
    {
        /// <summary>
        /// Асинхронно получает данные о пользователях.
        /// </summary>
        /// <param name="bot">Бот.</param>
        /// <param name="userIds">Идентификаторы пользователей (короткие имена, uid).</param>
        /// <param name="nameCase">Падеж.</param>
        /// <param name="fields">Дополнительные поля.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Данные о пользователях.</returns>
        public static async ValueTask<IEnumerable<User>> GetUserAsync(this IVkBot bot, string[] userIds, string nameCase = "nom", string[] fields = default, CancellationToken cancellationToken = default)
        {
            if (userIds is null)
                throw new ArgumentNullException(nameof(userIds));

            var args = new Dictionary<string, string>
            {
                ["name_case"] = nameCase
            };

            if (userIds.Length > 0)
                args.Add("user_ids", string.Join(",", userIds));

            if (fields?.Any() ?? false)
                args.Add("fields", string.Concat(",", fields));

            return await bot.ExecMethodAsync<IEnumerable<User>>("users.get", args, cancellationToken);
        }

        /// <summary>
        /// Возвращает текст, обернутый в упоминание для пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <param name="text">Текст.</param>
        /// <returns>Текст, обернутый в упоминание для пользователя.</returns>
        public static string GetUserTaggedText(this User user, string text)
        {
            return $"[id{ user.Id }|{text}]";
        }
    }
}