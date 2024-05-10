using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardsSite.Api.Controllers;

public class AuthController : ParentController
{
	private readonly IAuthService _authService;
	public AuthController(IAuthService authService)
	{

		_authService = authService;
	}
	[HttpPost("register")]
	public async Task<ResponseModal> Register(RegisterUserRequest registerUser)
		=> await _authService.Register(registerUser);

	[HttpPost("login")]
	public async Task<ResponseModal> Login(LoginUserRequest loginUser)
	=> await _authService.Login(loginUser);



}
