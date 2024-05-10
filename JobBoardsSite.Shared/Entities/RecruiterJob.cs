using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Shared.Entities;

public class RecruiterJob
{
	[Key]
	public int Id { get; set; }
	public int RecruiterId { get; set; }
	public ApplicationUser Recruiter { get; set; }


	public int JobId { get; set; }
	public JobItem JobItem { get; set; }

}
