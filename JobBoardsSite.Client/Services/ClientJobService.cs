using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Newtonsoft.Json.Linq;
using System.Net;

namespace JobBoardsSite.Client.Services
{
	public class ClientJobService : IClientJobService
	{
		private readonly IBaseService _baseService;


		public ClientJobService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseModal> CreateJob(CreateJobRequest jobRequest)
		{
			var response = await _baseService.SendRequest(new()
			{
				Method = ApiVerbs.POST,
				Data = jobRequest,
				Url = "api/job/create"

			});
			if (response.isSuccess)
			{
				return response;
			}
			else
			{
				throw new Exception(response.Message);
			}

			
		}


		public async Task<ResponseModal> EditJob(EditJobRequest jobRequest)
		{
			var response = await _baseService.SendRequest(new()
			{
				Method = ApiVerbs.POST,
				Data = jobRequest,
				Url = "api/job/edit"

			});
			if (response.isSuccess)
			{
				return response;
			}
			else
			{
				throw new Exception(response.Message);
			}


		}

		public async Task<JobItemResponse> GetJob(int id)
		{
			var response = await _baseService.SendRequest(new()
			{
				Method = ApiVerbs.GET,
				Url = "api/job/get-one/"+id

			});
			if (response.isSuccess)
			{
				var obj = response.Data as JObject;
				var data = obj.ToObject<JobItemResponse>();
				return data;

			}
			else
			{
				throw new Exception(response.Message);
			}
		}

		public async Task<List<JobListItemResponse>> GetJobs()
		{
			var response = await _baseService.SendRequest(new()
			{
				Method = ApiVerbs.GET,
				Url = "api/job/get-all"

			});
			if (response.isSuccess)
			{
				var obj = response.Data as JArray;
				var data = obj.ToObject<List<JobListItemResponse>>();

				return data;

			}
			else
			{
				throw new Exception(response.Message);
			}
		}

		public async Task<PaginationResponse> GetJobsPagination(PaginationRequest request)
		{
			
			var response = await _baseService.SendRequest(new()
			{
				Method = ApiVerbs.GET,
				Url = $"api/Job/get-all-query?PageNumber={request.PageNumber}&PageLimit={request.PageLimit}&WorkType={request.WorkType}&Country={request.Country}&Skills={request.Skills}"

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


		
	}
}
