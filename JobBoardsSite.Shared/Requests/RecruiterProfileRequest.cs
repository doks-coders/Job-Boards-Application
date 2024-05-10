using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Shared.Requests;

public class RecruiterProfileRequest
{


	[Required]
	public string Name { get; set; }

	[Required]
	public string Industry { get; set; }


	[Required]
	public string About { get; set; }

	[Required]
	public string PhoneNumber { get; set; }

	[Required]
	public string City { get; set; } = "";

	[Required]
	public string Country { get; set; } = "";

}
