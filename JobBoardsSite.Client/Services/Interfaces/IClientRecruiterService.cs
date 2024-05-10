using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;

namespace JobBoardsSite.Client.Services.Interfaces;

public interface IClientRecruiterService
{
	Task UpdateProfile(RecruiterProfileRequest request);

	Task<List<ApplicantsTableResponse>> GetApplicantsTable();

	Task<List<JobItemTableResponse>> GetJobsTable();

	Task<RecruiterResponse> GetRecruiterInfo(int id);

	Task<RecruiterResponse> GetMyRecruiterInfo();
}
