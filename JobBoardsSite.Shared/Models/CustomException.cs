using JobBoardsSite.Shared.Enums;

namespace JobBoardsSite.Shared.Models;

public class CustomException : Exception
{
	public CustomException(string exception) : base(exception)
	{

	}
	public CustomException(ErrorCodes exception) : base(exception.ToString())
	{

	}
	public CustomException(string[] exception) : base(string.Join(", ", exception))
	{

	}
}
