using Flurl;

namespace StarRepublic.SpotifyClient
{
    public sealed class Paged<TResponse> : IQuery<TResponse>
    {
        private readonly IQuery<TResponse> decoratedQuery;
        private readonly int pageSize;
        private readonly int page;

		public Paged(IQuery<TResponse> decoratedQuery, int pageSize, int page)
        {
            this.decoratedQuery = decoratedQuery;
            this.pageSize = pageSize;
            this.page = page;
        }

        public Url GetUrl()
        {
            return decoratedQuery.GetUrl()
                .SetQueryParams(new
                {
                    limit = pageSize,
                    offset = page * pageSize
                });
        }
    }
}
