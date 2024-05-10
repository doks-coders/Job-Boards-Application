using JobBoardsSite.Api.Extensions;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardsSite.Api.Controllers;

[Authorize]
public class ApplicantController : ParentController
{
	private readonly IApplicantService _applicantService;

	public ApplicantController(IApplicantService applicantService)
	{
		_applicantService = applicantService;
	}

	[HttpGet("search-applicants")]
	public async Task<ResponseModal> SearchApplicants([FromQuery] PaginationRequest request)
	=> await _applicantService.SearchApplicants(request);

	[HttpPost("update-applicant-info")]
	public async Task<ResponseModal> CreateRecruiterInfo([FromBody] ApplicantProfileRequest request)
	=> await _applicantService.UpdateApplicantInfo(User.GetUserId(), request);

	[HttpGet("job-apply/{id:int}")]
	public async Task<ResponseModal> JobApply(int id)
	=> await _applicantService.JobApply(User.GetUserId(), id);

	[HttpGet("get-applicant-info/{id:int}")]
	public async Task<ResponseModal> GetApplicantInfo(int id)
	=> await _applicantService.GetApplicantDetails(User.GetUserId(), id);

	[HttpGet("get-my-applicant-info")]
	public async Task<ResponseModal> GetMyApplicantInfo()
	=> await _applicantService.GetApplicantDetails(User.GetUserId());




}

/**
 * 
 */