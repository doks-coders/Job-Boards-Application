using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Shared.Entities;

public class AppUserRole : IdentityUserRole<int>
{
	[Key]
	public int Id { get; set; }
	public ApplicationUser AppUser { get; set; }
	public AppRole AppRole { get; set; }
}
