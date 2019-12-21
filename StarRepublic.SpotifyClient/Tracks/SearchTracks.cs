using System;
using Flurl;

namespace StarRepublic.SpotifyClient.Tracks
{
	public sealed class SearchTracks : IQuery<SearchTrackResponse>
	{
		private readonly string trackName;

		public SearchTracks(string trackName)
		{
			this.trackName = trackName ?? throw new ArgumentNullException(nameof(trackName));
		}

		public Url GetQueryUrl() => "/v1/search"
			.SetQueryParam("q", trackName)
			.SetQueryParam("type", "track");
	}
}
