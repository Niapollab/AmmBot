using System.ComponentModel.DataAnnotations;

namespace AmmBot.Service
{
    /// <summary>
    /// Представляет настройки VK бота.
    /// </summary>
    internal sealed class VkBotOptions
    {
        /// <summary>
        /// Токен.
        /// </summary>
        [Required]
        public string Token { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Таймаут перед повторной попыткой подключения к сети.
        /// </summary>
        public int TimeoutOfRetry { get; set; } = 5000;

        /// <summary>
        /// Long poll ожидание (задержка на сервере).
        /// </summary>
        public int LongPollWait { get; set; } = 5;
    }
}