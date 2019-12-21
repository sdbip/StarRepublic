using Flurl;

namespace StarRepublic.SpotifyClient.Recommendations
{
	public sealed class MakeRecommendation : IQuery<RecommendationsResponse>
	{
		private readonly string artistId;
		private readonly string trackId;

		public MakeRecommendation(string artistId = null, string trackId = null)
		{
			this.artistId = artistId;
			this.trackId = trackId;
		}

		public Url GetQueryUrl() => "/v1/recommendations"
			.SetQueryParams(new
			{
				seed_artists = artistId,
				seed_tracks = trackId,
				min_energy = 0.4,
				min_popularity = 50,
				market = "US",
				limit = 100
			});
	}
}
