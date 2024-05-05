using JobBoardsSite.Api.Extensions;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardsSite.Api.Controllers
{

	public class JobController : ParentController
	{
		private readonly IJobService _jobService;

		public JobController(IJobService jobService)
		{
			_jobService = jobService;
		}
		[Authorize]
		[HttpPost("create")]
		public async Task<ResponseModal> Create([FromBody] CreateJobRequest jobRequest)
		=> await _jobService.CreateJob(jobRequest,User.GetUserId());

		[HttpGet("get-all")]
		public async Task<ResponseModal> GetAllJobs()
		=> await _jobService.GetJobs();

		[HttpGet("get-one/{id:int}")]
		public async Task<ResponseModal> GetOneJob(int id)
		=> await _jobService.GetJob(id);

		[HttpGet("get-all-query")]
		public async Task<ResponseModal> GetAllQuery([FromQuery] PaginationRequest param)
		=> await _jobService.GetJobPagination(param);




	}
}
