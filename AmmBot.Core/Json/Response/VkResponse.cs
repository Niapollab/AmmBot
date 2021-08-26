using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Response
{
    /// <summary>
    /// Представляет ответ, возвращаемый при запросе к API.
    /// </summary>
    /// <typeparam name="T">Тип объекта, содержащегося в ответе.</typeparam>
    internal class VkResponse<T>
    {
        /// <summary>
        /// Объект ответа на запрос.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("response")]
        public T Response { get; init; }

        /// <summary>
        /// Объект ошибки.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("error")]
        public VkError Error { get; init; }
    }
}