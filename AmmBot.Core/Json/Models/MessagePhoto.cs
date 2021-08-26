using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет фотографию связанную с сообщением-действием в диалоге.
    /// </summary>
    public class MessagePhoto
    {
        /// <summary>
        /// Ссылка на фотографию 50x50.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("photo_50")]
        public string Photo50Url { get; init; }
        
        /// <summary>
        /// Ссылка на фотографию 100x100.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("photo_100")]
        public string Photo100Url { get; init; }

        /// <summary>
        /// Ссылка на фотографию 200x200.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("photo_200")]
        public string Photo200Url { get; init; }
    }
}