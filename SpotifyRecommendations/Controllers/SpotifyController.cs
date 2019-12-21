using System.Collections.Generic;
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
		public async Task<ActionResult<IEnumerable<string>>> Search([FromQuery] string searchTerm)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
				return BadRequest("Mandatory query property searchTerm not specified");
			var client = new SpotifyApiClient();
			var result = await client.SearchArtistsAsync(searchTerm);
			return Ok(result.Artists.Items.Select(artist => artist.Name));
		}
	}
}
