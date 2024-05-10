using System.Security.Claims;

namespace JobBoardsSite.ApplicationCore.Helpers
{
	public static class ClaimsExtensions
	{
		public static int GetUserId(this ClaimsPrincipal user)
		{
			return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
		}
	}
}
