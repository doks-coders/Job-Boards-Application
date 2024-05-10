using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Shared.Requests;


public class ApplicantProfileRequest
{
	[Required]
	public string Name { get; set; }

	[Required]
	[Phone]
	public string PhoneNumber { get; set; }

	[Required]
	public string Title { get; set; }

	[Required]
	public string Country { get; set; }

	[Required]
	public string AverageSalary { get; set; }


	[Required]
	public string SelectedSkills { get; set; }

	[Required]
	public string City { get; set; }

	[Required]
	public string ShortBio { get; set; }


	public string WorkExperiences { get; set; } = string.Empty;


}
