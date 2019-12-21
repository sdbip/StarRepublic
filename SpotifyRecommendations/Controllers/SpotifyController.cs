﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarRepublic.SpotifyClient;

namespace SpotifyRecommendations.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SpotifyController : ControllerBase
	{
		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<string>>> Search([FromQuery] string artist = null, [FromQuery] string track = null)
		{
			if (string.IsNullOrWhiteSpace(artist) && string.IsNullOrWhiteSpace(track))
				return BadRequest("One of artist or track must be specified");
			if (!string.IsNullOrWhiteSpace(artist) && !string.IsNullOrWhiteSpace(track))
				return BadRequest("Both artist and track may not be specified");

			if (string.IsNullOrWhiteSpace(artist))
			{
				var client = new SpotifyApiClient();
				var result = await client.SearchTracksAsync(track);
				return Ok(result.Tracks.Items.Select(item => item.Name));
			}
			else
			{
				var client = new SpotifyApiClient();
				var result = await client.SearchArtistsAsync(artist);
				return Ok(result.Artists.Items.Select(item => item.Name));
			}
		}
	}
}