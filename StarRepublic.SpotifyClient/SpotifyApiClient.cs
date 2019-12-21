using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

		public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query, int? limit = null, int? offset = null)
		{
			using var client = GetDefaultClient();
			var url = query.GetQueryUrl();

			if (limit != null)
				url = url.SetQueryParam("limit", limit);

			if (offset != null)
				url = url.SetQueryParam("offset", offset);

			var response = await client.GetStringAsync(url);

			return JsonConvert.DeserializeObject<TResponse>(response);
		}
	}
}
