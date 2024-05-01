using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using Newtonsoft.Json;

namespace JobBoardsSite.Client.Services
{
	public class BaseService : IBaseService
	{
		private readonly HttpClient _httpClient;
		public BaseService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<ResponseModal> SendRequest(RequestModal requestModal)
		{
			HttpResponseMessage response = new();
			StringContent content;

			try
			{
				switch (requestModal.Method)
				{
					case ApiVerbs.GET:
						response = await _httpClient.GetAsync(requestModal.Url);
						break;
					case ApiVerbs.POST:
						response = await _httpClient.PostAsJsonAsync(requestModal.Url, requestModal.Data);
						break;
					case ApiVerbs.DELETE:
						response = await _httpClient.DeleteAsync(requestModal.Url);
						break;
					case ApiVerbs.PATCH:
						response = await _httpClient.PatchAsJsonAsync(requestModal.Url, requestModal.Data);
						break;
				}


				if (response.IsSuccessStatusCode)
				{
					
					var apiContent = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ResponseModal>(apiContent);
				}
				else
				{
					var errorContent = await response.Content.ReadAsStringAsync();
					var errorModal = JsonConvert.DeserializeObject<ErrorResponseModal>(errorContent);
					throw new Exception($"Http Error Code: {response.StatusCode}, Message:{errorModal.Message}");
				}

			}
			catch (Exception ex)
			{
				throw new Exception($"Http Error Code: 500, Message:{ex.Message}");

			}

		}
	}
}
