using JobBoardsSite.Shared.Responses;

namespace JobBoardsSite.Client.Services.Interfaces;

public interface IManageLocalStorage
{
	Task AddUserToLocalStorage(AuthUserResponse user);
	Task RemoveUserFromLocalStorage();
	Task<AuthUserResponse?> GetUserFromLocalStorage();
}
