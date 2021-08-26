using System;
using System.Collections.Generic;
using System.Linq;
using AmmBot.Core.Json.Response;

namespace AmmBot.Core.Exceptions
{
    /// <summary>
    /// Представляет исключение при обращении к API ВКонтакте.
    /// </summary>
    public class VkApiException : Exception
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Текст ошибки.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Параметры, переданные в запросе, в котором возникла ошибка.
        /// </summary>
        public IEnumerable<RequestParams> RequestParams { get; }

        /// <summary>
        /// Инициализирует исключение при обращении к API ВКонтакте.
        /// </summary>
        /// <param name="errorCode">Код ошибки.</param>
        /// <param name="errorMessage">Текст ошибки.</param>
        /// <param name="requestParams">Параметры, переданные в запросе, в котором возникла ошибка.</param>
        public VkApiException(int errorCode, string errorMessage, IEnumerable<RequestParams> requestParams) : base(GenerateExceptionMessage(errorCode, errorMessage, requestParams))
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            RequestParams = requestParams;
        }

        /// <summary>
        /// Генерирует сообщение исключения.
        /// </summary>
        /// <param name="errorCode">Код ошибки.</param>
        /// <param name="errorMessage">Текст ошибки.</param>
        /// <param name="requestParams">Параметры, переданные в запросе, в котором возникла ошибка.</param>
        private static string GenerateExceptionMessage(int errorCode, string errorMessage, IEnumerable<RequestParams> requestParams)
        {
            return $"{errorMessage} ({errorCode}). Params: {string.Join(", ", requestParams.Select(param => $"{param.Key} = \"{param.Value}\""))}";
        }
    }
}