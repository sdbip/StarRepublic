using System;
using Flurl;

namespace StarRepublic.SpotifyClient.Artists
{
	public sealed class SearchArtists : IQuery<SearchArtistsResponse>
	{
		private readonly string artistName;

		public SearchArtists(string artistName)
		{
			this.artistName = artistName ?? throw new ArgumentNullException(nameof(artistName));
		}

		public Url GetQueryUrl() => "/v1/search"
			.SetQueryParam("q", artistName)
			.SetQueryParam("type", "artist");
	}
}
