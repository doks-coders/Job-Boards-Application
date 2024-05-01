using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobBoardsSite.Client.Services
{
	public class ClientAuthService : IClientAuthService
	{
		private readonly IBaseService _baseService;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly IManageLocalStorage _manageLocalStorage;

		public ClientAuthService(IBaseService baseService, AuthenticationStateProvider authenticationStateProvider, IManageLocalStorage manageLocalStorage)
		{
			_baseService = baseService;
			_authenticationStateProvider = authenticationStateProvider;
			_manageLocalStorage = manageLocalStorage;

			AuthenticationStateChanged += AuthStateChanged;


		}

		public async Task<AuthUserResponse> Register(RegisterUserRequest registerUser)
		{
			var response = await _baseService.SendRequest(
				new RequestModal()
				{
					Data = registerUser,
					Url = "api/auth/register",
					Method = ApiVerbs.POST,
				});

			if (response.isSuccess)
			{
				var obj = response.Data as JObject;
				var data = obj.ToObject<AuthUserResponse>();
				return data;

			}
			else
			{
				throw new Exception(response.Message);
			}
		}


		public async Task<AuthUserResponse> Login(LoginUserRequest loginUser)
		{
			var response = await _baseService.SendRequest(
				new RequestModal()
				{
					Data = loginUser,
					Url = "api/auth/login",
					Method = ApiVerbs.POST,
				});

			if (response.isSuccess)
			{
				var obj = response.Data as JObject;
				var data = obj.ToObject<AuthUserResponse>();
				return data;

			}
			else
			{
				throw new Exception(response.Message);
			}
		}

		public async Task<AuthenticationState> SignInUser(AuthUserResponse userResponse)
		{

			await _manageLocalStorage.AddUserToLocalStorage(userResponse);
			return await _authenticationStateProvider.GetAuthenticationStateAsync();
			//Emit Logged in event
		}

		public async Task<AuthenticationState> SignOutUser()
		{
			await _manageLocalStorage.RemoveUserFromLocalStorage();
			return await _authenticationStateProvider.GetAuthenticationStateAsync();

		}



		public AuthenticationState AuthenticationState { get; private set; } = new(new ClaimsPrincipal(new ClaimsIdentity()));

		private void AuthStateChanged(AuthenticationState authState)
		{
			AuthenticationState = authState;
		}

		public event Action<AuthenticationState> AuthenticationStateChanged;

		public void RaiseEventAuthenticationStateChanged(AuthenticationState state)
		{
			if (AuthenticationStateChanged != null)
			{
				AuthenticationStateChanged.Invoke(state);
			}
		}

	}
}
