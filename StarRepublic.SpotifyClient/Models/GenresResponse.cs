using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarRepublic.SpotifyClient.Models
{
    public class GenresResponse
    {
        [JsonProperty("genres")]
        public IList<string> Genres { get; set; }
    }
}
