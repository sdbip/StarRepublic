using StarRepublic.SpotifyClient.Models.Genres;

namespace StarRepublic.SpotifyClient
{
	public sealed class GenresQuery : IQuery<GenresResponse>
	{
		public string Url => "/v1/recommendations/available-genre-seeds";
		public object Params => new { };
	}
}
