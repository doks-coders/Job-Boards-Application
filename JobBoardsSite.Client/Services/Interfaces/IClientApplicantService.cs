using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;

namespace JobBoardsSite.Client.Services.Interfaces
{
	public interface IClientApplicantService
	{
		Task UpdateProfile(ApplicantProfileRequest request);

		Task<ResponseModal> JobApply(int id);

		Task<ApplicantResponse> GetApplicantInfo(int id);

		Task<ApplicantResponse> GetApplicantMyInfo();

		Task<PaginationResponse> SearchApplicants(PaginationRequest request);

	}
}
