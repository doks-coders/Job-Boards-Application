using Microsoft.AspNetCore.Identity;

namespace JobBoardsSite.Shared.Entities;

public class AppRole : IdentityRole<int>
{
	public ICollection<AppUserRole> UserRoles { get; set; }
}
