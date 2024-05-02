using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
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

		[HttpPost("create")]
		public async Task<ResponseModal> Create([FromBody]CreateJobRequest jobRequest)
		=> await _jobService.CreateJob(jobRequest);
	}
}
