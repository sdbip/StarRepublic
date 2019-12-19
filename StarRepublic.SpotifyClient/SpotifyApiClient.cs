using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;

namespace StarRepublic.SpotifyClient
{
    public sealed class SpotifyApiClient
    {
        private const string ClientId = "302efa1fb6d24e659ed0554d3733e888";
        private const string ClientSecret = "8fdd72a5335d46459f27009d50ab9f58";

        private const string BaseUrl = "https://api.spotify.com/";

        public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query)
        {
            var url = query.GetUrl();
            return await QueryAsync<TResponse>(url);
        }

        private async Task<TResponse> QueryAsync<TResponse>(Url url)
        {
            using var client = GetDefaultClient();
            var response = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<TResponse>(response);
        }

        private static HttpClient GetDefaultClient()
        {
            var authHandler = new SpotifyAuthClientCredentialsHttpMessageHandler(
                ClientId,
                ClientSecret,
                new HttpClientHandler());

            return new HttpClient(authHandler)
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }
    }
}
