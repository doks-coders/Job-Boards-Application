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

		

	}
}
