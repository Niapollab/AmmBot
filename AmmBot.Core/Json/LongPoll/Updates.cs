using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmmBot.Core.LongPoll
{
    /// <summary>
    /// Представляет обновление, пришедшее с Long poll сервера.
    /// </summary>
    public class Updates
    {
        /// <summary>
        /// Время обновления.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("ts")]
        public string Ts { get; init; }

        /// <summary>
        /// Список данных об обновлениях.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("updates")]
        public IEnumerable<UpdateData> Items { get; init; }

        /// <summary>
        /// Код ошибки (0, если ошибки нет).
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("failed")]
        public int Failed { get; init; }

        /// <summary>
        /// Идентификатор группы.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("group_id")]
        public long GroupId { get; init; }

        /// <summary>
        /// Идентификатор события.
        /// </summary>

        [JsonInclude]
        [JsonPropertyName("event_id")]
        public string EventId { get; init; }
    }
}