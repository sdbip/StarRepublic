using Flurl;
using StarRepublic.SpotifyClient.Models.Genres;

namespace StarRepublic.SpotifyClient
{
	public sealed class GenresQuery : IQuery<GenresResponse>
	{
        public Url GetUrl() => "/v1/recommendations/available-genre-seeds";
    }
}
