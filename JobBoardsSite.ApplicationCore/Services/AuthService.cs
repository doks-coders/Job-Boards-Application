using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ITokenService _tokenService;
		public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_tokenService = tokenService;
		}

		public async Task<ResponseModal> Register(RegisterUserRequest userRequest)
		{
			var userExist = await _userManager.FindByEmailAsync(userRequest.Email);
			if (userExist != null) throw new CustomException(ErrorCodes.DatabaseError);

			if (userRequest.Password != userRequest.Verify) throw new CustomException(ErrorCodes.PasswordsMismatch);
			var user = new ApplicationUser()
			{
				Email = userRequest.Email,
				UserName = userRequest.Email,
				UserType = userRequest.UserType

			};
			var res = await _userManager.CreateAsync(user, userRequest.Password);
			if (!res.Succeeded) throw new CustomException(res.Errors.Select(e => e.Description).ToArray());

			return new ResponseModal()
			{
				Data = new AuthUserResponse() { Email = user.Email, Token = _tokenService.GenerateToken(user) },
				Message = "Created Successfully"
			};
		}

		public async Task<ResponseModal> Login(LoginUserRequest userRequest)
		{
			var user = await _userManager.FindByEmailAsync(userRequest.Email);
			if (user == null) throw new CustomException(ErrorCodes.EmailDoesntExist);

			var isCorrect = await _userManager.CheckPasswordAsync(user, userRequest.Password);

			if (!isCorrect) throw new CustomException(ErrorCodes.WrongPassword);

			return new ResponseModal()
			{
				Data = new AuthUserResponse() { Email = user.Email, Token = _tokenService.GenerateToken(user) },
				Message = "Logged in Successfully",
			};
		}
	}
}
