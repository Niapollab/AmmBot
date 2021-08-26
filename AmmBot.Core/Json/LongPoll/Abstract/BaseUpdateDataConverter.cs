using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmmBot.Core.LongPoll.Abstract
{
    /// <summary>
    /// Представляет базовый конвертер обновлений, пришедших с Long poll сервера.
    /// </summary>
    internal abstract class BaseUpdateDataConverter : JsonConverter<UpdateData>
    {
        /// <summary>
        /// Выполняет десериализацию объекта.
        /// </summary>
        /// <param name="type">Тип объекта.</param>
        /// <param name="element">Элемент.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Десериализованный объект.</returns>
        protected abstract object ParseObject(string type, JsonElement element, JsonSerializerOptions options);

        /// <summary>
        /// Выполняет десериализацию данного типа.
        /// </summary>
        /// <param name="reader">Считыватель.</param>
        /// <param name="typeToConvert">Тип, к которому производится приведение.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Десериализацию данного типа.</returns>
        public override UpdateData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonElement updateDataRaw = JsonDocument.ParseValue(ref reader).RootElement;

            string type = updateDataRaw.GetProperty("type").GetString();
            JsonElement objectRaw = updateDataRaw.GetProperty("object");
            
            return new UpdateData
            {
                Type = type,
                Object = ParseObject(type, objectRaw, options)
            };
        }
        
        /// <summary>
        /// Выполняет сериализацию данного типа.
        /// </summary>
        /// <param name="writer">Писатель.</param>
        /// <param name="value">Сериализуемое значение.</param>
        /// <param name="options">Опции.</param>
        public override void Write(Utf8JsonWriter writer, UpdateData value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize<UpdateData>(writer, value, options);
        }
    }
}