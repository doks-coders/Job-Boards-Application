using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces
{
	public interface IJobService
	{
		Task<ResponseModal> CreateJob(CreateJobRequest jobRequest,int userId);
		Task<ResponseModal> GetJobs();
		Task<ResponseModal> GetJob(int id,ClaimsPrincipal user);
		Task<ResponseModal> GetJobPagination(PaginationRequest request);
		Task<ResponseModal> EditJob(EditJobRequest jobRequest);
	}
}
