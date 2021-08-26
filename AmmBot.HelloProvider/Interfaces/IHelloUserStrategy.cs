using System.Threading;
using System.Threading.Tasks;
using AmmBot.Core.Interfaces;
using AmmBot.Core.Json.Models;

namespace AmmBot.HelloProvider.Interfaces
{
    public interface IHelloUserStrategy
    {
        ValueTask<long> SayHelloAsync(IVkBot bot, long peerId, User user, CancellationToken cancellationToken = default);
    }
}
