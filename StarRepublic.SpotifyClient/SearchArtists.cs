using System;
using Flurl;
using StarRepublic.SpotifyClient.Models.Artist;

namespace StarRepublic.SpotifyClient
{
	public sealed class SearchArtists : IQuery<SearchArtistResponse>
	{
		private readonly string artistName;

		public SearchArtists(string artistName)
		{
			this.artistName = artistName ?? throw new ArgumentNullException(nameof(artistName));
		}

		public Url GetQueryUrl() => new Url("/v1/search")
			.SetQueryParam("q", artistName)
			.SetQueryParam("type", "artist");
	}
}
