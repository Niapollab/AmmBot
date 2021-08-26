using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет контейнер для пересылки сообщений в запросе.
    /// </summary>
    public class Forward
    {
        /// <summary>
        /// Идентификатор владельца.
        /// </summary>
        [JsonInclude]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("owner_id")]
        public long OwnerId { get; init; }

        /// <summary>
        /// Идентификатор отправителя.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("peer_id")]
        public long PeerId { get; init; }

        /// <summary>
        /// Идентификаторы пересылаемых сообщений беседы.
        /// </summary>
        [JsonInclude]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("conversation_message_ids")]
        public long[] ConversationMessageIds { get; init; }

        /// <summary>
        /// Идентификаторы пересылаемых личных сообщений.
        /// </summary>
        [JsonInclude]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message_ids")]
        public long[] MessageIds { get; init; }

        /// <summary>
        /// Является ли сообщение ответом.
        /// </summary>
        [JsonInclude]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("is_reply")]
        public bool IsReply { get; init; }
    }
}