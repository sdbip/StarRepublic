using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpotifyRecommendations.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SpotifyController : ControllerBase
	{
		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<string>>> Search([FromQuery] string searchTerm)
		{
			if (searchTerm is null)
				return await Task.FromResult(new[] { "Bon Jovi", "Bonnie Raitt", "Joan Jett" });
			else
				return await Task.FromResult(new[] { searchTerm, searchTerm });
		}
	}
}
