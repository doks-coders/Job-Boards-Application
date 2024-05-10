using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using System.Security.Claims;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces;

public interface IJobService
{
	Task<ResponseModal> CreateJob(CreateJobRequest jobRequest, int userId);
	Task<ResponseModal> GetJobs();
	Task<ResponseModal> GetJob(int id, ClaimsPrincipal user);
	Task<ResponseModal> GetJobPagination(PaginationRequest request);
	Task<ResponseModal> EditJob(EditJobRequest jobRequest);
}
