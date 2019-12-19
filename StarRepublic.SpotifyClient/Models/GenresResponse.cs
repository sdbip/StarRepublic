using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarRepublic.SpotifyClient.Models.Genres
{
    public sealed class GenresResponse
    {
        [JsonProperty("genres")]
        public IReadOnlyCollection<string> Genres { get; set; }
    }
}
