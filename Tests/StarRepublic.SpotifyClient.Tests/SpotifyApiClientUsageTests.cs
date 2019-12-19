using System;
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
            var query = new SearchArtistsQuery("Bon Jovi");
            var artists = QuerySync(query).Artists;

            Assert.That(artists, Is.Not.Null);
            Assert.That(artists!.Total, Is.EqualTo(artists.Items.Count));
            Assert.That(artists.Items.Select(artist => artist.Name).Contains("Bon Jovi"));
            Assert.That(artists.Items.Select(artist => artist.Name).Contains("Jon Bon Jovi"));
        }

        [Test]
        public void GenresIncludeRock()
        {
            var query = new GenresQuery();
            var response = QuerySync(query);

            Assert.That(response.Genres.Contains("rock"));
        }

        [Test]
        public void GetsRecommendationsWithArtistSeed()
        {
            var query = new RecommendationsQuery(artistId: "4NHQUGzhtTLFvgF5SZesLK");
            var recommendations = QuerySync(query);

            Assert.That(recommendations, Is.Not.Null);
            Assert.That(recommendations.Seeds.Count, Is.EqualTo(1));
            Assert.That(recommendations.Tracks, Is.Not.Empty);
        }

        [Test]
        public void GetsRecommendationsWithTrackSeed()
        {
            var query = new RecommendationsQuery(trackId: "0c6xIDDpzE81m2q797ordA");
            var recommendations = QuerySync(query);

            Assert.That(recommendations, Is.Not.Null);
            Assert.That(recommendations.Seeds.Count, Is.EqualTo(1));
            Assert.That(recommendations.Tracks, Is.Not.Empty);
        }

        [Test]
        public void GetsRecommendationsWithArtistAndTrackSeed()
        {
            var query = new RecommendationsQuery(artistId: "4NHQUGzhtTLFvgF5SZesLK", trackId: "0c6xIDDpzE81m2q797ordA");
            var recommendations = QuerySync(query);

            Assert.That(recommendations, Is.Not.Null);
            Assert.That(recommendations.Seeds.Count, Is.EqualTo(2));
            Assert.That(recommendations.Tracks, Is.Not.Empty);
        }

        private TResult QuerySync<TResult>(IQuery<TResult> query) =>
            client.QueryAsync(query).AwaitResult();
    }
}
