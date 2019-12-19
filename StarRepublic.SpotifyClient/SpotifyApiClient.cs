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

        private static HttpClient GetDefaultClient()
        {
            var authHandler = new SpotifyAuthClientCredentialsHttpMessageHandler(
                ClientId,
                ClientSecret,
                new HttpClientHandler());

            var client = new HttpClient(authHandler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            return client;
        }

        public async Task<SearchArtistResponse> SearchArtistsAsync(string artistName, int? limit = null, int? offset = null)
        {
            var url = new Url("/v1/search")
                        .SetQueryParam("q", artistName)
                        .SetQueryParam("type", "artist");

            if (limit != null)
                url = url.SetQueryParam("limit", limit);

            if (offset != null)
                url = url.SetQueryParam("offset", offset);

            return await Query<SearchArtistResponse>(url);
        }

        public async Task<GenresResponse> GetGenres()
        {
            var url = new Url("/v1/recommendations/available-genre-seeds");
            return await Query<GenresResponse>(url);
        }

        public async Task<RecommendationsResponse> GetRecommendationsAsync(string artistId = null, string trackId = null)
        {
            var url = new Url("/v1/recommendations")
                .SetQueryParams(new
                {
                    seed_artists = artistId,
                    seed_tracks = trackId,
                    min_energy = 0.4,
                    min_popularity = 50,
                    market = "US",
                    limit = 100
                });
            return await Query<RecommendationsResponse>(url);
        }

        private async Task<TResponse> Query<TResponse>(Url url)
        {
            using var client = GetDefaultClient();
            var response = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<TResponse>(response);
        }
    }
}
