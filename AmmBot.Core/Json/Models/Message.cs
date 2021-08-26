using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет сообщение.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Идентификатор сообщения (для личных сообщений).
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("id")]
        public long Id { get; init; }

        /// <summary>
        /// Дата в UnixTime.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("date")]
        public long Date { get; init; }

        /// <summary>
        /// Идентификатор точки назначения.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("peer_id")]
        public long PeerId { get; init; }

        /// <summary>
        /// Идентификатор отправителя.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("from_id")]
        public long FromId { get; init; }

        /// <summary>
        /// 1, если сообщение является отправленным ботом.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("out")]
        public int Out { get; init; }
        
        /// <summary>
        /// Идентификатор сообщения (для бесед).
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("conversation_message_id")]
        public long ConversationMessageId { get; init; }

        /// <summary>
        /// Текстовое сообщение.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("text")]
        public string Text { get; init; }

        /// <summary>
        /// Случайный идентификатор сообщения.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("random_id")]
        public long RandomId { get; init; }
        
        /// <summary>
        /// Вложения.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("attachments")]
        public IEnumerable<BaseAttachment> Attachments { get; init; }

        /// <summary>
        /// Является ли сообщение важным.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("important")]
        public bool IsImportant { get; init; }

        /// <summary>
        /// Геопозиция.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("geo")]
        public Geoposition Geoposition { get; init; }

        /// <summary>
        /// Полезная нагрузка (дополнительные сведения, закрепленные за этим сообщением).
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("payload")]
        public string Payload { get; init; }

        /// <summary>
        /// Пересланные сообщения.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("fwd_messages")]
        public IEnumerable<Message> ForwardedMessages { get; init; }

        /// <summary>
        /// Сообщение-действие в диалоге.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("action")]
        public MessageAction Action { get; init; }
    }
}