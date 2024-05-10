namespace JobBoardsSite.Shared.Responses;

public class RecruiterResponse
{

	public string Name { get; set; }

	public string Email { get; set; }

	public string Industry { get; set; }


	public bool isAuthUser { get; set; } = false;


	public string About { get; set; }


	public string PhoneNumber { get; set; }


	public string City { get; set; }


	public string Country { get; set; }
}
