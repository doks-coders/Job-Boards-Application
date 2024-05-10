using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Newtonsoft.Json.Linq;

namespace JobBoardsSite.Client.Services;

public class ClientRecruiterService : IClientRecruiterService
{
	private readonly IBaseService _baseService;

	public ClientRecruiterService(IBaseService baseService)
	{
		_baseService = baseService;
	}


	public async Task UpdateProfile(RecruiterProfileRequest request)
	{
		var res = await _baseService.SendRequest(new() { Data = request, Method = ApiVerbs.POST, Url = "api/Recruiter/update-recruiter-info" });

		if (res.isSuccess)
		{
			return;
		}
		throw new Exception(res.Message);
	}

	public async Task<List<ApplicantsTableResponse>> GetApplicantsTable()
	{
		var response = await _baseService.SendRequest(new()
		{
			Method = ApiVerbs.GET,
			Url = "api/Recruiter/get-applicant-table"

		});
		if (response.isSuccess)
		{

			var obj = response.Data as JArray;
			var data = obj.ToObject<List<ApplicantsTableResponse>>();
			return data;
		}
		else
		{
			throw new Exception(response.Message);
		}

	}

	public async Task<List<JobItemTableResponse>> GetJobsTable()
	{
		var response = await _baseService.SendRequest(new()
		{
			Method = ApiVerbs.GET,
			Url = "api/Recruiter/get-jobs-table"
		});
		if (response.isSuccess)
		{

			var obj = response.Data as JArray;
			var data = obj.ToObject<List<JobItemTableResponse>>();
			return data;
		}
		else
		{
			throw new Exception(response.Message);
		}

	}



	public async Task<RecruiterResponse> GetRecruiterInfo(int id)
	{
		var response = await _baseService.SendRequest(
		new RequestModal()
		{
			Url = $"api/Recruiter/get-recruiter-info/{id}",
			Method = ApiVerbs.GET,
		});

		if (response.isSuccess)
		{
			var obj = response.Data as JObject;
			var data = obj.ToObject<RecruiterResponse>();
			return data;

		}
		else
		{
			throw new Exception(response.Message);
		}


	}
	public async Task<RecruiterResponse> GetMyRecruiterInfo()
	{
		var response = await _baseService.SendRequest(
		new RequestModal()
		{
			Url = $"api/Recruiter/get-my-recruiter-info",
			Method = ApiVerbs.GET,
		});

		if (response.isSuccess)
		{
			var obj = response.Data as JObject;
			var data = obj.ToObject<RecruiterResponse>();
			return data;

		}
		else
		{
			throw new Exception(response.Message);
		}
	}
}
