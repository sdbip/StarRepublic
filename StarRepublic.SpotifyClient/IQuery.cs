using Flurl;

namespace StarRepublic.SpotifyClient
{
	public interface IQuery<TResponse>
	{
		public Url GetQueryUrl();
	}
}
