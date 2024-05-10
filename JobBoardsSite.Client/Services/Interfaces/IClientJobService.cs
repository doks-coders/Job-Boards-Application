using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;

namespace JobBoardsSite.Client.Services.Interfaces
{
	public interface IClientJobService
	{
		Task<ResponseModal> CreateJob(CreateJobRequest jobRequest);

		Task<ResponseModal> EditJob(EditJobRequest jobRequest);

		Task<List<JobListItemResponse>> GetJobs();

		Task<JobItemResponse> GetJob(int id);

		Task<PaginationResponse> GetJobsPagination(PaginationRequest request);
	}
}
