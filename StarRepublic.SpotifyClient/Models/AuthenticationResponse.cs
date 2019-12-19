using Newtonsoft.Json;

/* Hint: Use http://jsonutils.com/ to generate models from JSON responses from the API. */
#nullable disable

namespace StarRepublic.SpotifyClient.Models
{
    public sealed class AuthenticationResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
