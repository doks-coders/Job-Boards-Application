using JobBoardsSite.Shared.Models;

namespace JobBoardsSite.Client.Services.Interfaces
{
	public interface IBaseService
	{
		Task<ResponseModal> SendRequest(RequestModal requestModal);
	}
}
