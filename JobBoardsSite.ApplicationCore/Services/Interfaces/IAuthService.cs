using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces
{
	public interface IAuthService
	{
		Task<ResponseModal> Register(RegisterUserRequest userRequest);
		Task<ResponseModal> Login(LoginUserRequest userRequest);
	}
}
