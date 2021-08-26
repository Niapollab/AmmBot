using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AmmBot.Core.Exceptions;
using AmmBot.Core.Interfaces;
using AmmBot.Core.LongPoll;
using AmmBot.Core.Json.Models;
using AmmBot.Core.Json.Response;

namespace AmmBot.Core
{
    public class VkBot : IVkBot
    {
        public static readonly Lazy<JsonSerializerOptions> s_JsonSerializerOptions = new Lazy<JsonSerializerOptions>(() => new JsonSerializerOptions()
        {
            Converters = {
                new UpdateDataConverter()
            }
        });

        public const long GroupConversationOffset = 2000000000;

        private const string VkApiUrl = "https://api.vk.com/method/";

        public const string ApiVersion = "5.80";

        private readonly HttpClient _client;

        private bool _disposed = false;

        public string Token { get; }

        public VkBot(string token, HttpClient client = null)
        {
            _client = client ?? new HttpClient();
            Token = token;
        }

        ~VkBot()
        {
            if (_disposed)
                Dispose();
        } 

        public async ValueTask<T> ExecMethodAsync<T>(string methodName, IEnumerable<KeyValuePair<string, string>> args, CancellationToken cancellationToken = default)
        {
            if (methodName is null)
                throw new ArgumentNullException(nameof(methodName));

            if (methodName is null)
                throw new ArgumentNullException(nameof(methodName));

            string url = GetApiUrl(methodName, args, Token, ApiVersion);
            cancellationToken.ThrowIfCancellationRequested();
            using Stream responseStream = await _client.GetStreamAsync(url, cancellationToken);
            var vkResponse = await JsonSerializer.DeserializeAsync<VkResponse<T>>(responseStream, null, cancellationToken);
            
            if (vkResponse.Error is not null)
                throw new VkApiException(vkResponse.Error.ErrorCode, vkResponse.Error.ErrorMessage, vkResponse.Error.RequestParams);

            return vkResponse.Response;
        }

        public async ValueTask<Updates> GetLongPollUpdatesAsync(LongPollServerData serverData,
            int wait = 25,
            int version = 3,
            CancellationToken cancellationToken = default)
        {
            string url = GetLongPollUrl(serverData.Server, serverData.Key, serverData.Ts, wait, version);
            cancellationToken.ThrowIfCancellationRequested();
            
            using Stream responseStream = await _client.GetStreamAsync(url, cancellationToken);
            Updates updates = await JsonSerializer.DeserializeAsync<Updates>(responseStream, s_JsonSerializerOptions.Value, cancellationToken);
            
            if (!string.IsNullOrEmpty(updates.Ts))
                serverData.Ts = long.Parse(updates.Ts);

            return updates;
        }

        private static string GetApiUrl(string methodName,
            IEnumerable<KeyValuePair<string, string>> args,
            string token,
            string version)
        {
            string @params = string.Join("&", args.Select(param => $"{param.Key}={param.Value}"));
            return $"{VkApiUrl}{methodName}{(@params.Length > 0 ? "?" : "")}{@params}&access_token={token}&v={version}";
        }

        private static string GetLongPollUrl(string server,
            string key,
            long ts,
            int wait,
            int version)
        {
            return $"{server}?act=a_check&key={key}&ts={ts}&wait={wait}&version={version}";
        }

        public void Dispose()
        {
            _disposed = true;
            _client?.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}