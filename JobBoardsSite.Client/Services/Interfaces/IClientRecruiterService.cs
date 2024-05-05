using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.Client.Services.Interfaces
{
	public interface IClientRecruiterService
	{
		Task UpdateProfile(RecruiterProfileRequest request);
	}
}
