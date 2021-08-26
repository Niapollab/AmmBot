using System;
using System.Buffers;
using System.Text.Json;

namespace AmmBot.Core.Json.Extensions
{
    /// <summary>
    /// Представляет расширения для работы с JSON.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Десериализует JsonElement в заданномый тип.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="options">Опции.</param>
        /// <typeparam name="T">Тип элемента.</typeparam>
        /// <returns>Десериализованный элемент.</returns>
        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
        }

        /// <summary>
        /// Десериализует JsonDocument в заданномый тип.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <param name="options">Опции.</param>
        /// <typeparam name="T">Тип элемента.</typeparam>
        /// <returns>Десериализованный элемент.</returns>
        public static T ToObject<T>(this JsonDocument document, JsonSerializerOptions options = null)
        {
            if (document is null)
                throw new ArgumentNullException(nameof(document));
            
            return document.RootElement.ToObject<T>(options);
        }       
    }
}