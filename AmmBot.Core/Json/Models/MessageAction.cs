using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет сообщение-действие в диалоге.
    /// </summary>
    public class MessageAction
    {
        /// <summary>
        /// Тип действия.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("type")]
        public string Type { get; init; }

        /// <summary>
        /// Идентификатор пользователя, связанного с действием.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("member_id")]
        public long MemberId { get; init; }

        /// <summary>
        /// Контекст действия.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("text")]
        public string Text { get; init; }

        /// <summary>
        /// Электронная почта пользователя, связанная с действием.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("email")]
        public string Email { get; init; }

        /// <summary>
        /// Фотография, связанная с действием.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("photo")]
        public MessagePhoto Photo { get; init; }
    }
}