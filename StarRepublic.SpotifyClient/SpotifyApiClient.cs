using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;
using StarRepublic.SpotifyClient.Models.Artists;
using StarRepublic.SpotifyClient.Models.Genres;
using StarRepublic.SpotifyClient.Models.Recommendations;

namespace StarRepublic.SpotifyClient
{
    public sealed class SpotifyApiClient
    {
        private const string ClientId = "302efa1fb6d24e659ed0554d3733e888";
        private const string ClientSecret = "8fdd72a5335d46459f27009d50ab9f58";

        private const string BaseUrl = "https://api.spotify.com/";

        public async Task<SearchArtistResponse> SearchArtistsAsync(string artistName, int? limit = null, int? offset = null)
        {
            var query = new SearchArtistsQuery(artistName);
            var url = new Url(query.Url).SetQueryParams(query.Params);

            if (limit != null)
                url = url.SetQueryParam("limit", limit);

            if (offset != null)
                url = url.SetQueryParam("offset", offset);

            return await QueryAsync<SearchArtistResponse>(url);
        }

        public async Task<GenresResponse> GetGenres()
        {
            var query = new GenresQuery();
            return await QueryAsync(query);
        }

        public async Task<RecommendationsResponse> GetRecommendationsAsync(string artistId = null, string trackId = null)
        {
            var query = new RecommendationsQuery(artistId, trackId);
            return await QueryAsync(query);
        }

        public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query)
        {
            var url = new Url(query.Url)
                .SetQueryParams(query.Params, Flurl.NullValueHandling.Remove);
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
