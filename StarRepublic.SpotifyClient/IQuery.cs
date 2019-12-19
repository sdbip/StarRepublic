using Flurl;

namespace StarRepublic.SpotifyClient
{
	public interface IQuery<TResponse>
	{
        Url GetUrl();
    }
}
