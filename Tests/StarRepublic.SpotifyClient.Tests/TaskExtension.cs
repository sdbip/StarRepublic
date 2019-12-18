using System.Threading.Tasks;

namespace StarRepublic.SpotifyClient.Tests
{
	internal static class TaskExtension
	{
		public static T AwaitResult<T>(this Task<T> task) =>
			task.GetAwaiter().GetResult();
	}
}
