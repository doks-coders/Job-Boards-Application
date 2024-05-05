using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.Client.Services.Interfaces
{
	public interface IClientApplicantService
	{
		Task UpdateProfile(ApplicantProfileRequest request);
	}
}
