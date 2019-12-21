using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;
using StarRepublic.SpotifyClient.Models.Artist;
using StarRepublic.SpotifyClient.Models.Tracks;

namespace StarRepublic.SpotifyClient
{
	public class SpotifyApiClient
	{
		private const string ClientId = "996d0037680544c987287a9b0470fdbb";
		private const string ClientSecret = "5a3c92099a324b8f9e45d77e919fec13";

		protected const string BaseUrl = "https://api.spotify.com/";

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

		public async Task<SearchTrackResponse> SearchTracksAsync(string trackName, int? limit = null, int? offset = null)
		{
			var client = GetDefaultClient();

			var url = new Url("/v1/search")
						.SetQueryParam("q", trackName)
						.SetQueryParam("type", "track");

			if (limit != null)
				url = url.SetQueryParam("limit", limit);

			if (offset != null)
				url = url.SetQueryParam("offset", offset);

			var response = await client.GetStringAsync(url);

			return JsonConvert.DeserializeObject<SearchTrackResponse>(response);
		}

		public async Task<SearchArtistResponse> SearchArtistsAsync(string artistName, int? limit = null, int? offset = null)
		{
			var client = GetDefaultClient();

			var url = new Url("/v1/search")
						.SetQueryParam("q", artistName)
						.SetQueryParam("type", "artist");

			if (limit != null)
				url = url.SetQueryParam("limit", limit);

			if (offset != null)
				url = url.SetQueryParam("offset", offset);

			var response = await client.GetStringAsync(url);

			return JsonConvert.DeserializeObject<SearchArtistResponse>(response);
		}
	}
}
