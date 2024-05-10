namespace JobBoardsSite.Shared.Responses;

public class PaginationResponse
{
	public int TotalPages { get; set; }
	public int PageNumber { get; set; }
	public object Items { get; set; }
}
