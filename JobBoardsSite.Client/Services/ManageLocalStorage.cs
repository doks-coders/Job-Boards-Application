using Blazored.LocalStorage;
using JobBoardsSite.Client.Constants;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;

namespace JobBoardsSite.Client.Services;

public class ManageLocalStorage : IManageLocalStorage
{
	private readonly ILocalStorageService _localStorageService;

	public ManageLocalStorage(ILocalStorageService localStorageService)
	{
		_localStorageService = localStorageService;
	}

	public async Task AddUserToLocalStorage(AuthUserResponse user)
	{
		await _localStorageService.SetItemAsync(LocalStorageKeys.User, user);
	}

	public async Task<AuthUserResponse?> GetUserFromLocalStorage()
	{
		return await _localStorageService.GetItemAsync<AuthUserResponse?>(LocalStorageKeys.User);
	}

	public async Task RemoveUserFromLocalStorage()
	{
		await _localStorageService.RemoveItemAsync(LocalStorageKeys.User);
	}
}
