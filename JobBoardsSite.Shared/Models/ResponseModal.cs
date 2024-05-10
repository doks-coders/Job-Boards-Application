namespace JobBoardsSite.Shared.Models;

public class ResponseModal
{
	public string Message { get; set; }
	public bool isSuccess { get; set; } = true;
	public object Data { get; set; }
}
