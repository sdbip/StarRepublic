using System;
using Flurl;

namespace StarRepublic.SpotifyClient
{
	public class Limited<TResponse> : IQuery<TResponse>
	{
		private readonly IQuery<TResponse> baseQuery;
		private readonly int limit;
		private readonly int offset;

		public Limited(IQuery<TResponse> baseQuery, int limit, int offset = 0)
		{
			this.baseQuery = baseQuery ?? throw new ArgumentNullException(nameof(baseQuery));
			this.limit = limit;
			this.offset = offset;
		}

		public Url GetQueryUrl() =>
			baseQuery.GetQueryUrl().SetQueryParams(new { limit, offset });
	}

	public static class LimitedQuery
	{
		public static IQuery<TResponse> Limited<TResponse>(this IQuery<TResponse> baseQuery, int limit, int offset = 0)
		{
			return new Limited<TResponse>(baseQuery, limit, offset);
		}
	}
}
