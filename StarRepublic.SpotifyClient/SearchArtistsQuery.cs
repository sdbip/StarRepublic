using System;
using Flurl;
using StarRepublic.SpotifyClient.Models.Artists;

namespace StarRepublic.SpotifyClient
{
	public class SearchArtistsQuery : IQuery<SearchArtistResponse>
	{
		private readonly string artistName;

		public SearchArtistsQuery(string name)
		{
			artistName = name ?? throw new ArgumentNullException(nameof(name));
		}

		public Url GetUrl() => "/v1/search"
			.SetQueryParams(new
			{
				q = artistName,
				type = "artist"
			});
	}
}
