using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces;

public interface IApplicantService
{
	Task<ResponseModal> UpdateApplicantInfo(int userId, ApplicantProfileRequest request);

	Task<ResponseModal> JobApply(int userId, int jobId);

	Task<ResponseModal> GetApplicantDetails(int userId, int paramUserId);

	Task<ResponseModal> GetApplicantDetails(int userId);

	Task<ResponseModal> SearchApplicants(PaginationRequest request);
}
