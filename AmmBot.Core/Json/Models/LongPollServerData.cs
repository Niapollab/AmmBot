using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет данные о Long Poll сервере.
    /// </summary>
    public class LongPollServerData
    {
        /// <summary>
        /// Ключ.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("key")]
        public string Key { get; init; }

        /// <summary>
        /// Сервер.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("server")]
        public string Server { get; init; }

        /// <summary>
        /// Временной штамп.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("ts")]
        public long Ts { get; set; }
    }
}