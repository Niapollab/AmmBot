using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет данные о месте.
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Идентификатор места.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("id")]
        public long Id { get; init; }

        /// <summary>
        /// Название места.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("title")]
        public string Title { get; init; }

        /// <summary>
        /// Широта.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("latitude")]
        public double Latitude { get; init; }

        /// <summary>
        /// Долгота.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("longitude")]
        public double Longitude { get; init; }
        
        /// <summary>
        /// Время создания в UnixTime.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("created")]
        public long Created { get; init; }

        /// <summary>
        /// Ссылка на иконку.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("icon")]
        public string IconUrl { get; init; }
        
        /// <summary>
        /// Страна.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("country")]
        public string Country { get; init; }

        /// <summary>
        /// Город.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("city")]
        public string City { get; init; }
    }
}