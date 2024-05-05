using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.Client.Services
{
	public class ClientApplicantService:IClientApplicantService
	{
		private readonly IBaseService _baseService;

		public ClientApplicantService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task UpdateProfile(ApplicantProfileRequest request)
		{
			var res = await _baseService.SendRequest(new() { Data = request,Method=ApiVerbs.POST,Url= "api/Applicant/update-applicant-info" });

			if (res.isSuccess)
			{
				return;
			}
			throw new Exception(res.Message);
		}
		
	}
}
