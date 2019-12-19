using Flurl;

namespace StarRepublic.SpotifyClient
{
    internal class Limited<TResponse> : IQuery<TResponse>
	{
		private readonly IQuery<TResponse> unlimited;
		private readonly int limit;

		public Limited(IQuery<TResponse> unlimited, int limit)
		{
			this.unlimited = unlimited;
			this.limit = limit;
		}

        public Url GetUrl() =>
            unlimited.GetUrl().SetQueryParam("limit", limit);
    }
}
