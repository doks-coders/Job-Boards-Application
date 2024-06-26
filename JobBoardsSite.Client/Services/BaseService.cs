﻿using JobBoardsSite.Client.Pages.Applicant.JobInformation;
using JobBoardsSite.Client.Pages.MiscComponents;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Constants;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using System.Text;

namespace JobBoardsSite.Client.Services;

public class BaseService : IBaseService
{
	private readonly HttpClient _httpClient;
	private readonly IManageLocalStorage _manageLocalStorage;
	private readonly NavigationManager _navigationManager;
	private readonly IDialogService _dialogService;
	public BaseService(HttpClient httpClient, IManageLocalStorage manageLocalStorage, IDialogService dialogService)
	{
		_httpClient = httpClient;
		_manageLocalStorage = manageLocalStorage;
		_dialogService = dialogService;
	}



	public async Task<ResponseModal> SendRequest(RequestModal requestModal)
	{
		HttpResponseMessage response = new();
		StringContent content;

		var request = new HttpRequestMessage();
		request.RequestUri = new(UrlConstants.BaseBackendURL + requestModal.Url);

		//Adds auth Headers if any
		request = await AddAuthorizationHeaders(request, _manageLocalStorage);

		try
		{
			switch (requestModal.Method)
			{
				case ApiVerbs.GET:
					request.Method = HttpMethod.Get;
					response = await _httpClient.SendAsync(request);
					break;
				case ApiVerbs.POST:
					request.Method = HttpMethod.Post;
					request.Content = ConvertClassObjToContent(requestModal.Data);

					response = await _httpClient.SendAsync(request);
					break;
				case ApiVerbs.DELETE:
					request.Method = HttpMethod.Delete;
					response = await _httpClient.SendAsync(request);
					break;
				case ApiVerbs.PATCH:
					request.Method = HttpMethod.Patch;
					request.Content = ConvertClassObjToContent(requestModal.Data);

					response = await _httpClient.SendAsync(request);
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

			var parameters = new DialogParameters<SimpleDialog>();
			parameters.Add(x => x.ContentText, ex.Message);

			var options = new DialogOptions { CloseOnEscapeKey = true, };
			_dialogService.Show<SimpleDialog>("Error", parameters);

			throw new Exception($"Http Error Code: 500, Message:{ex.Message}");



		}

	}

	private StringContent ConvertClassObjToContent(object data)
	{
		var jsonRequest = JsonConvert.SerializeObject(data);
		var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");
		return content;

	}

	private async Task<HttpRequestMessage> AddAuthorizationHeaders(HttpRequestMessage request, IManageLocalStorage localStorage)
	{
		var user = await localStorage.GetUserFromLocalStorage();
		if (user != null)
		{
			request.Headers.Add("Authorization", $"Bearer {user.Token}");

		}
		return request;
	}
}


/**
 * try
		{
			switch (requestModal.Method)
			{
				case ApiVerbs.GET:
					response = await _httpClient.GetAsync(requestModal.Url);

					response = await
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
 */