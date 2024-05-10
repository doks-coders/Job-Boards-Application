using JobBoardsSite.Shared.Enums;

namespace JobBoardsSite.Shared.Models;

public class RequestModal
{
	public ApiVerbs Method { get; set; }
	public string Url { get; set; }
	public object Data { get; set; }

}
