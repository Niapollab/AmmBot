using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AmmBot.Core.LongPoll;
using AmmBot.Core.Json.Models;

namespace AmmBot.Core.Interfaces
{
    /// <summary>
    /// Представляет интерфейс бота социальной сети ВКонтакте.
    /// </summary>
    public interface IVkBot : IDisposable
    {
        /// <summary>
        /// Токен.
        /// </summary>
        string Token { get; }

        /// <summary>
        /// Асинхронно выполняет удаленный метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="args">Параметры.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <typeparam name="T">Тип, возвращаемого результата.</typeparam>
        /// <returns>Результат работы удаленного метода./returns>
        ValueTask<T> ExecMethodAsync<T>(
            string methodName,
            IEnumerable<KeyValuePair<string, string>> args,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Асинхронно получает обновления с сервера Long poll.
        /// </summary>
        /// <param name="serverData">Данные сервера.</param>
        /// <param name="wait">Время ожидания (в секундах).</param>
        /// <param name="version"Версия.></param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Обновления с сервера Long poll.</returns>
        ValueTask<Updates> GetLongPollUpdatesAsync(LongPollServerData serverData,
            int wait,
            int version,
            CancellationToken cancellationToken = default);
    }
}