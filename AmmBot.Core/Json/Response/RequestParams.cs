using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Response
{
    /// <summary>
    /// Представляет параметры запроса к API.
    /// </summary>
    public class RequestParams
    {
        /// <summary>
        /// Ключ.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("key")]
        public string Key { get; init; }
        
        /// <summary>
        /// Значение.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("value")]
        public string Value { get; init; }
    }
}