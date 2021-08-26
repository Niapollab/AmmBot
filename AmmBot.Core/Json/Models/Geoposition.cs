using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет геопозицию.
    /// </summary>
    public class Geoposition
    {
        /// <summary>
        /// Тип геопозиции.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("type")]
        public string Type { get; init; }

        /// <summary>
        /// Координаты.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("coordinates")]
        public double[] Coordinates  { get; init; }

        /// <summary>
        /// Место.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("place")]
        public Place Place { get; init; }
    }
}