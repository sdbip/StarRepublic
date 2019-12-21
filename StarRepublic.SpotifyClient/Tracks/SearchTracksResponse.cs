using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarRepublic.SpotifyClient.Tracks
{
	public sealed class ExternalUrls
	{
		[JsonProperty("spotify")]
		public string Spotify { get; set; }
	}

	public sealed class Artist
	{
		[JsonProperty("external_urls")]
		public ExternalUrls ExternalUrls { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }
	}

	public sealed class Image
	{
		[JsonProperty("height")]
		public int Height { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("width")]
		public int Width { get; set; }
	}

	public sealed class Album
	{
		[JsonProperty("album_type")]
		public string AlbumType { get; set; }

		[JsonProperty("artists")]
		public IList<Artist> Artists { get; set; }

		[JsonProperty("available_markets")]
		public IList<string> AvailableMarkets { get; set; }

		[JsonProperty("external_urls")]
		public ExternalUrls ExternalUrls { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("images")]
		public IList<Image> Images { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("release_date")]
		public string ReleaseDate { get; set; }

		[JsonProperty("release_date_precision")]
		public string ReleaseDatePrecision { get; set; }

		[JsonProperty("total_tracks")]
		public int TotalTracks { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }
	}

	public sealed class ExternalIds
	{
		[JsonProperty("isrc")]
		public string Isrc { get; set; }
	}

	public sealed class Item
	{
		[JsonProperty("album")]
		public Album Album { get; set; }

		[JsonProperty("artists")]
		public IList<Artist> Artists { get; set; }

		[JsonProperty("available_markets")]
		public IList<string> AvailableMarkets { get; set; }

		[JsonProperty("disc_number")]
		public int DiscNumber { get; set; }

		[JsonProperty("duration_ms")]
		public int DurationMs { get; set; }

		[JsonProperty("explicit")]
		public bool Explicit { get; set; }

		[JsonProperty("external_ids")]
		public ExternalIds ExternalIds { get; set; }

		[JsonProperty("external_urls")]
		public ExternalUrls ExternalUrls { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("is_local")]
		public bool IsLocal { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("popularity")]
		public int Popularity { get; set; }

		[JsonProperty("preview_url")]
		public string PreviewUrl { get; set; }

		[JsonProperty("track_number")]
		public int TrackNumber { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }
	}

	public sealed class Tracks
	{
		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("items")]
		public IList<Item> Items { get; set; }

		[JsonProperty("limit")]
		public int Limit { get; set; }

		[JsonProperty("next")]
		public string Next { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("previous")]
		public object Previous { get; set; }

		[JsonProperty("total")]
		public int Total { get; set; }
	}

	public sealed class SearchTrackResponse
	{
		[JsonProperty("tracks")]
		public Tracks Tracks { get; set; }
	}
}
