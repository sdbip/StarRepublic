using System;
using StarRepublic.SpotifyClient.Models.Artists;
using StarRepublic.SpotifyClient.Models.Recommendations;

namespace StarRepublic.SpotifyClient
{
    public sealed class RecommendationsQuery : IQuery<RecommendationsResponse>
    {
        private readonly string? artistId;
        private readonly string? trackId;

        public string Url => "/v1/recommendations";
        public object Params => new
        {
            seed_artists = artistId,
            seed_tracks = trackId,
            min_energy = 0.4,
            min_popularity = 50,
            market = "US",
            limit = 100
        };

        public RecommendationsQuery(string? artistId, string? trackId)
        {
            this.artistId = artistId;
            this.trackId = trackId;
        }
    }

    public class SearchArtistsQuery : IQuery<SearchArtistResponse>
    {
        private readonly string artistName;

        public string Url => "/v1/search";
        public object Params => new
        {
            q = artistName,
            type = "artist"
        };

        public SearchArtistsQuery(string name)
        {
            artistName = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
