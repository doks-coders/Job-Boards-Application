using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces
{
	public interface IApplicantService
	{
		Task<ResponseModal> UpdateApplicantInfo(int userId, ApplicantProfileRequest request);

		Task<ResponseModal> JobApply(int userId, int jobId);

		Task<ResponseModal> GetApplicantDetails(int userId, int paramUserId);

		Task<ResponseModal> GetApplicantDetails(int userId);

		Task<ResponseModal> SearchApplicants(PaginationRequest request);
	}
}
