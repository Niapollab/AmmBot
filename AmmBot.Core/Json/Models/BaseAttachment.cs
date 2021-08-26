using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет базовое вложение.
    /// </summary>
    public class BaseAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("type")]
        public string Type { get; init; }
    }
}