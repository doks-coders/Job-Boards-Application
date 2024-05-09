using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Newtonsoft.Json.Linq;

namespace JobBoardsSite.Client.Services
{
	public class ClientApplicantService:IClientApplicantService
	{
		private readonly IBaseService _baseService;

		public ClientApplicantService(IBaseService baseService)
		{
			_baseService = baseService;
		}
		//

		public async Task<PaginationResponse> SearchApplicants(PaginationRequest request)
		{
			
			var response = await _baseService.SendRequest(new()
			{
				Method = ApiVerbs.GET,
				Url = $"api/Applicant/search-applicants?PageNumber={request.PageNumber}&PageLimit={request.PageLimit}&Country={request.Country}&Skills={request.Skills}"
			});

			if (response.isSuccess)
			{
				var obj = response.Data as JObject;
				var data = obj.ToObject<PaginationResponse>();
				return data;
			}
			else
			{
				throw new Exception(response.Message);
			}
		}



		public async Task UpdateProfile(ApplicantProfileRequest request)
		{
			var res = await _baseService.SendRequest(new() { Data = request,Method=ApiVerbs.POST,Url= "api/Applicant/update-applicant-info" });

			if (res.isSuccess)
			{
				return;
			}
			throw new Exception(res.Message);
		}
	
		public async Task<ResponseModal> JobApply(int id)
		{
			var res = await _baseService.SendRequest(new() { Method = ApiVerbs.GET, Url = $"api/Applicant/job-apply/{id}" });
			if (res.isSuccess)
			{
				return res;
			}
			throw new Exception(res.Message);
		}
		
		public async Task<ApplicantResponse> GetApplicantInfo(int id)
		{
				var response = await _baseService.SendRequest(
				new RequestModal()
				{
					Url = $"api/Applicant/get-applicant-info/{id}",
					Method = ApiVerbs.GET,
				});

			if (response.isSuccess)
			{
				var obj = response.Data as JObject;
				var data = obj.ToObject<ApplicantResponse>();
				return data;

			}
			else
			{
				throw new Exception(response.Message);
			}
		}


		public async Task<ApplicantResponse> GetApplicantMyInfo()
		{
			var response = await _baseService.SendRequest(
			new RequestModal()
			{
				Url = $"api/Applicant/get-my-applicant-info",
				Method = ApiVerbs.GET,
			});

			if (response.isSuccess)
			{
				var obj = response.Data as JObject;
				var data = obj.ToObject<ApplicantResponse>();
				return data;

			}
			else
			{
				throw new Exception(response.Message);
			}
		}

	}
}
