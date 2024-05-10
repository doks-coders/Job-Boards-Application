using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces;

public interface IRecruiterService
{
	Task<ResponseModal> UpdateRecruiter(int userId, RecruiterProfileRequest request);
	Task<ResponseModal> GetMyJobs(int userId);
	Task<ResponseModal> GetMyApplicants(int userId);
	Task<ResponseModal> GetMyRecruiterInfo(int userId);
	Task<ResponseModal> GetRecruiterInfo(int userId, int paramUserId);
}
