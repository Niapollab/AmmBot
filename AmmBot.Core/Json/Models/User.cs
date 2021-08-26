using System.Text.Json.Serialization;

namespace AmmBot.Core.Json.Models
{
    /// <summary>
    /// Представляет пользователя.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("id")]
        public long Id { get; init; }

        /// <summary>
        /// Имя.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("first_name")]
        public string FirstName { get; init; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("last_name")]
        public string LastName { get; init; }

        /// <summary>
        /// Является ли пользователь удаленным.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("deactivated")]
        public string Deactivated { get; init; }

        /// <summary>
        /// Является ли страница пользователь скрытой.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("hidden")]
        public int Hidden { get; init; }
    }
}