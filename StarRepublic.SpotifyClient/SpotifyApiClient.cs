using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarRepublic.SpotifyClient.Authentication;

namespace StarRepublic.SpotifyClient
{
	public sealed class SpotifyApiClient
	{
		private const string ClientId = "996d0037680544c987287a9b0470fdbb";
		private const string ClientSecret = "5a3c92099a324b8f9e45d77e919fec13";

		private const string BaseUrl = "https://api.spotify.com/";

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

		public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query)
		{
			using var client = GetDefaultClient();
			var url = query.GetQueryUrl();
			var response = await client.GetStringAsync(url);
			return JsonConvert.DeserializeObject<TResponse>(response);
		}
	}
}
