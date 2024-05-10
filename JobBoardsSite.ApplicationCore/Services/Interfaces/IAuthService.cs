using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces;

public interface IAuthService
{
	Task<ResponseModal> Register(RegisterUserRequest userRequest);
	Task<ResponseModal> Login(LoginUserRequest userRequest);
}
