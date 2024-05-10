using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components.Authorization;

namespace JobBoardsSite.Client.Services.Interfaces;

public interface IClientAuthService
{
	Task<AuthUserResponse> Register(RegisterUserRequest registerUser);

	Task<AuthUserResponse> Login(LoginUserRequest loginUser);

	Task<AuthenticationState> SignInUser(AuthUserResponse userResponse);

	Task<AuthenticationState> SignOutUser();

	event Action<AuthenticationState> AuthenticationStateChanged;

	AuthenticationState AuthenticationState { get; }

	void RaiseEventAuthenticationStateChanged(AuthenticationState state);
}
