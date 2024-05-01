using JobBoardsSite.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces
{
	public interface ITokenService
	{
		string GenerateToken(ApplicationUser user);
	}
}
