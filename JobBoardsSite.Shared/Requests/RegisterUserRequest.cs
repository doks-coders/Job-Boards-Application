using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{
	public record RegisterUserRequest(string Email,string UserType, string Password, string Verify);
	
}
