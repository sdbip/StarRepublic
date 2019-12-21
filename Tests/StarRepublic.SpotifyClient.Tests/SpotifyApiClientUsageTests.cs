using System.Linq;
using NUnit.Framework;

namespace StarRepublic.SpotifyClient.Tests
{
	public sealed class SpotifyApiClientUsageTests
	{
		private readonly SpotifyApiClient client = new SpotifyApiClient();

		[Test]
		public void FindsBonJovi()
		{
			var query = new SearchArtists("Bon Jovi");
			var artists = client.QueryAsync(query).GetAwaiter().GetResult()?.Artists;

			Assert.That(artists, Is.Not.Null);
			Assert.That(artists.Total, Is.EqualTo(artists.Items.Count));
			Assert.That(artists.Items.Select(artist => artist.Name).Contains("Bon Jovi"));
			Assert.That(artists.Items.Select(artist => artist.Name).Contains("Jon Bon Jovi"));
		}

		[Test]
		public void FindsTracks()
		{
			var query = new SearchTracks("Highway to Hell");
			var tracks = client.QueryAsync(query).GetAwaiter().GetResult()?.Tracks;

			Assert.That(tracks, Is.Not.Null);
			Assert.That(tracks.Limit, Is.EqualTo(tracks.Items.Count));
			Assert.That(tracks.Items.Select(artist => artist.Name).Contains("Highway to Hell"));
		}

		[Test]
		public void CanLimitResult()
		{
			const int limit = 2;
			var unlimited = new SearchArtists("Bon Jovi");
			var limited = unlimited.Limited(limit);

			var unlimitedResult = client.QueryAsync(unlimited).GetAwaiter().GetResult().Artists;
			var limitedResult = client.QueryAsync(limited).GetAwaiter().GetResult().Artists;

			Assert.That(limitedResult.Total, Is.EqualTo(unlimitedResult.Total));
			Assert.That(limitedResult.Items.Count, Is.EqualTo(limit));
		}
	}
}
