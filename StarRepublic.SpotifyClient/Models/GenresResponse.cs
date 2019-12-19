using System.Collections.Generic;
using Newtonsoft.Json;

#nullable disable

namespace StarRepublic.SpotifyClient.Models.Genres
{
    public sealed class GenresResponse
    {
        [JsonProperty("genres")]
        public IReadOnlyCollection<string> Genres { get; set; }
    }
}
