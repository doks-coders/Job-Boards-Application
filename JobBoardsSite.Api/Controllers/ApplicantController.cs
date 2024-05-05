using JobBoardsSite.Api.Extensions;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardsSite.Api.Controllers
{
	public class ApplicantController : ParentController
	{
		private readonly IApplicantService _applicantService;

		public ApplicantController(IApplicantService applicantService)
		{
			_applicantService = applicantService;
		}

		[HttpPost("update-applicant-info")]
		public async Task<ResponseModal> CreateRecruiterInfo([FromBody] ApplicantProfileRequest request)
		=> await _applicantService.UpdateApplicantInfo(User.GetUserId(), request);

	}
}
