using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarRepublic.SpotifyClient;
using StarRepublic.SpotifyClient.Artists;
using StarRepublic.SpotifyClient.Recommendations;
using StarRepublic.SpotifyClient.Tracks;

namespace SpotifyRecommendations.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public sealed class SpotifyController : ControllerBase
	{
		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<ItemDto>>> Search([FromQuery] string? artist = null, [FromQuery]string? track = null)
		{
			if (string.IsNullOrWhiteSpace(artist) && string.IsNullOrWhiteSpace(track))
				return BadRequest("One of artist or track must be specified");
			if (!string.IsNullOrWhiteSpace(artist) && !string.IsNullOrWhiteSpace(track))
				return BadRequest("Both artist and track may not be specified");

			if (string.IsNullOrWhiteSpace(artist))
			{
				var query = new SearchTracks(track!);
				var result = await QuerySpotifyAsync(query);
				return Ok(result.Tracks.Items.Select(item => new ItemDto(ItemType.Track, item.Id, item.Name, item.Artists.FirstOrDefault().Name)));
			}
			else
			{
				var query = new SearchArtists(artist);
				var result = await QuerySpotifyAsync(query);
				return Ok(result.Artists.Items.Select(item => new ItemDto(ItemType.Artist, item.Id, item.Name)));
			}
		}

		[HttpGet("make-recommendations")]
		public async Task<ActionResult<IEnumerable<ItemDto>>> MakeRecommendations([FromQuery] string seed, [FromQuery] ItemType type)
		{
			if (string.IsNullOrWhiteSpace(seed))
				return BadRequest($"Missing required parameter {nameof(seed)}");

			var query = new MakeRecommendation(type, seed);
			var result = await QuerySpotifyAsync(query);
			return Ok(result.Tracks.Select(item => new ItemDto(ItemType.Track, item.Id, item.Name, item.Artists.FirstOrDefault()?.Name)));
		}

		private async Task<TResponse> QuerySpotifyAsync<TResponse>(IQuery<TResponse> query)
		{
			var client = new SpotifyApiClient();
			return await client.QueryAsync(query);
		}

		public sealed class ItemDto
		{
			public ItemType Type { get; }
			public string Id { get; }
			public string Name { get; }
			public string? ArtistName { get; }

			public ItemDto(ItemType type, string id, string name, string? artistName = null)
			{
				Type = type;
				Id = id;
				Name = name;
				ArtistName = artistName;
			}
		}
	}
}
