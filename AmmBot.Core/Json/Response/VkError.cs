using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Response
{
    /// <summary>
    /// Представляет ошибку, возвращаемую при запросе к API.
    /// </summary>
    internal class VkError
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; init; }
        
        /// <summary>
        /// Текст ошибки.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("error_msg")]
        public string ErrorMessage { get; init; }

        /// <summary>
        /// Параметры, переданные в запросе, в котором возникла ошибка.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("request_params")]
        public IEnumerable<RequestParams> RequestParams { get; init; }
    }
}