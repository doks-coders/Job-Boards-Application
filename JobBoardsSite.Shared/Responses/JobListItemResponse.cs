namespace JobBoardsSite.Shared.Responses;

public class JobListItemResponse
{
	public int Id { get; set; }

	public string CompanyName { get; set; }

	public string CompanyImageUrl { get; set; }

	public string JobTitle { get; set; }


	public string Salary { get; set; }


	public string SelectedSkills { get; set; }


	public string WorkLocationType { get; set; }
}
