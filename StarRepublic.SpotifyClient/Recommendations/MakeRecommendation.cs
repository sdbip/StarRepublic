using System;
using Flurl;

namespace StarRepublic.SpotifyClient.Recommendations
{
	public enum ItemType { Artist, Track }

	public sealed class MakeRecommendation : IQuery<RecommendationsResponse>
	{
		private readonly ItemType type;
		private readonly string seed;

		public MakeRecommendation(ItemType type, string seed)
		{
			this.type = type;
			this.seed = seed ?? throw new ArgumentNullException(nameof(seed));
		}

		public Url GetQueryUrl() => "/v1/recommendations"
			.SetQueryParams(new
			{
				seed_artists = type == ItemType.Artist ? seed : null,
				seed_tracks = type == ItemType.Track ? seed : null,
				min_energy = 0.4,
				min_popularity = 50,
				market = "US",
				limit = 100
			});
	}
}
