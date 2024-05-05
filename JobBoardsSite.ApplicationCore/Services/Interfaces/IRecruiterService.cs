using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces
{
	public interface IRecruiterService
	{
		Task<ResponseModal> UpdateRecruiter(int userId, RecruiterProfileRequest request);
	}
}
