using Flurl;

namespace StarRepublic.SpotifyClient
{
	public interface IQuery<TResponse>
	{
        Url GetUrl();
    }

    public static class QueryDecorators
    {
        public static IQuery<TResponse> Limited<TResponse>(this IQuery<TResponse> self, int limit) =>
            new Limited<TResponse>(self, limit);

        public static IQuery<TResponse> Paged<TResponse>(this IQuery<TResponse> self, int pageSize, int page) =>
            new Paged<TResponse>(self, pageSize, page);
    }
}
