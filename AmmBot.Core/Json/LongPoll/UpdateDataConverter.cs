using System.Text.Json;
using AmmBot.Core.Json.Extensions;
using AmmBot.Core.LongPoll.Abstract;
using AmmBot.Core.Json.Models;

namespace AmmBot.Core.LongPoll
{
    /// <summary>
    /// Представляет конвертер обновлений, пришедших с Long poll сервера.
    /// </summary>
    internal class UpdateDataConverter : BaseUpdateDataConverter
    {
        /// <summary>
        /// Выполняет десериализацию объекта.
        /// </summary>
        /// <param name="type">Тип объекта.</param>
        /// <param name="element">Элемент.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Десериализованный объект.</returns>
        protected override object ParseObject(string type, JsonElement element, JsonSerializerOptions options)
        {
            return type switch
            {
                "message_new" => element.ToObject<Message>(options),
                _ => null
            };
        }
    }
}