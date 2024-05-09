using Azure.Core;
using JobBoardsSite.Api.Extensions;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardsSite.Api.Controllers
{
	public class RecruiterController : ParentController
	{
		private IRecruiterService _recruiterService;

		public RecruiterController(IRecruiterService recruiterService)
		{
			_recruiterService = recruiterService;
		}

		[HttpPost("update-recruiter-info")]
		public async Task<ResponseModal> CreateRecruiterInfo([FromBody] RecruiterProfileRequest request)
		=> await _recruiterService.UpdateRecruiter(User.GetUserId(), request);


		[HttpGet("get-my-recruiter-info")]
		public async Task<ResponseModal> GetMyRecruiterInfo()
		=> await _recruiterService.GetMyRecruiterInfo(User.GetUserId());

		[HttpGet("get-recruiter-info/{id:int}")]
		public async Task<ResponseModal> GetRecruiterInfo(int id)
		=> await _recruiterService.GetRecruiterInfo(User.GetUserId(), id);

		[HttpGet("get-applicant-table")]
		public async Task<ResponseModal> GetApplicantsTable()
		=> await _recruiterService.GetMyApplicants(User.GetUserId());

		[HttpGet("get-jobs-table")]
		public async Task<ResponseModal> GetJobsTable()
		=> await _recruiterService.GetMyJobs(User.GetUserId());



	}
}
