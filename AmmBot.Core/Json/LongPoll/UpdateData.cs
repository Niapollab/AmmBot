using System.Text.Json.Serialization;

namespace AmmBot.Core.LongPoll
{
    /// <summary>
    /// Представлет данные обновления пришедшие с Long poll сервера.
    /// </summary>
    public class UpdateData
    {
        /// <summary>
        /// Тип обновления.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("type")]
        public string Type { get; init; }

        /// <summary>
        /// Объект обновления.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("object")]
        public object Object { get; init; }
    }
}