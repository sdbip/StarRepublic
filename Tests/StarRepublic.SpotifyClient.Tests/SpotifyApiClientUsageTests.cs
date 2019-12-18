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
            var artists = client.SearchArtistsAsync("Bon Jovi")
                .AwaitResult()?
                .Artists;

            Assert.That(artists, Is.Not.Null);
            Assert.That(artists.Total, Is.EqualTo(artists.Items.Count));
            Assert.That(artists.Items.Select(artist => artist.Name).Contains("Bon Jovi"));
            Assert.That(artists.Items.Select(artist => artist.Name).Contains("Jon Bon Jovi"));
        }

        [Test]
        public void GenresIncludeRock()
        {
            var response = client.GetGenres()
                .AwaitResult();

            Assert.That(response.Genres.Contains("rock"));
        }
    }
}
