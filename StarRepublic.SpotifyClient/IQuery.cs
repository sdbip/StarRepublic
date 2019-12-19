namespace StarRepublic.SpotifyClient
{
	public interface IQuery<TResponse>
	{
		string Url { get; }
        object Params { get; }
    }
}
