using System;
using Flurl;
using StarRepublic.SpotifyClient.Models.Tracks;

namespace StarRepublic.SpotifyClient
{
	public sealed class SearchTracks : IQuery<SearchTrackResponse>
	{
		private readonly string trackName;

		public SearchTracks(string trackName)
		{
			this.trackName = trackName ?? throw new ArgumentNullException(nameof(trackName));
		}

		public Url GetQueryUrl() => new Url("/v1/search")
			.SetQueryParam("q", trackName)
			.SetQueryParam("type", "track");
	}
}
