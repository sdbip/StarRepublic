﻿using System.Collections.Generic;
using Newtonsoft.Json;

// Not happy about disabling nullability here, but also not sure how
// to fix it.
//
// Since this is the result of parsing JSON (using Newtonsoft.Json),
// it is obviously not possible to guarantee that the properties are
// not null. Yet using this and checking for null everywhere is
// impractical. I'm just going to assume that the Spotify API keeps
// its promise.

#nullable disable

namespace StarRepublic.SpotifyClient.Recommendations
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

	public sealed class Track
	{
		[JsonProperty("artists")]
		public IReadOnlyCollection<Artist> Artists { get; set; }

		[JsonProperty("disc_number")]
		public int DiscNumber { get; set; }

		[JsonProperty("duration_ms")]
		public int DurationMs { get; set; }

		[JsonProperty("explicit")]
		public bool Explicit { get; set; }

		[JsonProperty("external_urls")]
		public ExternalUrls ExternalUrls { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("is_playable")]
		public bool IsPlayable { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("preview_url")]
		public string PreviewUrl { get; set; }

		[JsonProperty("track_number")]
		public int TrackNumber { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }
	}

	public sealed class Seed
	{
		[JsonProperty("initialPoolSize")]
		public int InitialPoolSize { get; set; }

		[JsonProperty("afterFilteringSize")]
		public int AfterFilteringSize { get; set; }

		[JsonProperty("afterRelinkingSize")]
		public int AfterRelinkingSize { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}

	public sealed class MakeRecommendationsResponse
	{
		[JsonProperty("tracks")]
		public IReadOnlyCollection<Track> Tracks { get; set; }

		[JsonProperty("seeds")]
		public IReadOnlyCollection<Seed> Seeds { get; set; }
	}
}
