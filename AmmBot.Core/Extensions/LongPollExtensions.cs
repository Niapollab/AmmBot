using System.Threading;
using System.Threading.Tasks;
using AmmBot.Core.Interfaces;
using AmmBot.Core.Json.Models;
using System.Collections.Generic;
using AmmBot.Core.LongPoll;
using System.Runtime.CompilerServices;

namespace AmmBot.Core.Extensions
{
    /// <summary>
    /// Представляет расширения для работы с Long poll.
    /// </summary>
    public static class LongPollExtensions
    {
        /// <summary>
        /// Асинхронно получает данные о Long poll сервере.
        /// </summary>
        /// <param name="bot">Бот.</param>
        /// <param name="groupId">Идентификатор группы.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Данные о Long poll сервере.</returns>
        public async static ValueTask<LongPollServerData> GetLongPollServerAsync(this IVkBot bot, long groupId = default, CancellationToken cancellationToken = default)
        {
            return await bot.ExecMethodAsync<LongPollServerData>("groups.getLongPollServer", new Dictionary<string, string>
            {
                ["group_id"] = groupId.ToString()
            }, cancellationToken);
        }

        /// <summary>
        /// Возвращает асинхронный бесконечное перечисление Long poll событий. 
        /// </summary>
        /// <param name="bot">Бот.</param>
        /// <param name="groupId">Идентификатор группы.</param>
        /// <param name="wait">Время ожидания (в секундах).</param>
        /// <param name="version">Версия.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Бесконечное перечисление Long poll событий.</returns>
        public async static IAsyncEnumerable<UpdateData> LongPoll(this IVkBot bot,
            long groupId = default,
            int wait = 25,
            int version = 3,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            LongPollServerData serverData = await bot.GetLongPollServerAsync(groupId, cancellationToken);
            while (true)
            {
                Updates updates = await bot.GetLongPollUpdatesAsync(serverData, wait, version, cancellationToken);

                if (updates.Failed == 1)
                {
                    if (updates.Failed == 2 || updates.Failed == 3)
                        serverData = await bot.GetLongPollServerAsync(groupId, cancellationToken);
                    continue;
                }

                if (updates.Items == null)
                    continue;

                foreach (UpdateData update in updates.Items)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    yield return update;
                }
            }
        }
    }
}