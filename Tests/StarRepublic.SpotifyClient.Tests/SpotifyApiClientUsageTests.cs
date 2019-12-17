using System.Linq;
using NUnit.Framework;
using StarRepublic.SpotifyClient.Models;

namespace StarRepublic.SpotifyClient.Tests
{
	public sealed class SpotifyApiClientUsageTests
	{
		private readonly SpotifyApiClient client = new SpotifyApiClient();

		[Test]
		public void FindsBonJovi()
		{
			var artists = CallClient("Bon Jovi");

			Assert.That(artists, Is.Not.Null);
			Assert.That(artists.Total, Is.EqualTo(artists.Items.Count));
			Assert.That(artists.Items.Select(artist => artist.Name).Contains("Bon Jovi"));
			Assert.That(artists.Items.Select(artist => artist.Name).Contains("Jon Bon Jovi"));
		}

		private SearchArtistCollection CallClient(string artistName)
		{
			return client.SearchArtistsAsync(artistName).GetAwaiter().GetResult()?.Artists;
		}
	}
}
