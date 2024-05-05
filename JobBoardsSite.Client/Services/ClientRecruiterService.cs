using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Requests;

namespace JobBoardsSite.Client.Services
{
	public class ClientRecruiterService : IClientRecruiterService
	{
		private readonly IBaseService _baseService;

		public ClientRecruiterService(IBaseService baseService)
		{
			_baseService = baseService;
		}


		public async Task UpdateProfile(RecruiterProfileRequest request)
		{
			var res = await _baseService.SendRequest(new() { Data = request, Method = ApiVerbs.POST, Url = "api/Recruiter/update-recruiter-info" });

			if (res.isSuccess)
			{
				return;
			}
			throw new Exception(res.Message);
		}
	}
}
