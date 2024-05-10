using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Shared.Entities;

public class BaseEntity
{
	[Key]
	public int Id { get; set; }

	public DateTime Created { get; set; }

	public DateTime Updated { get; set; }

	public BaseEntity()
	{
		if (Created != Updated)
		{
			Updated = DateTime.Now;
		}
		else
		{
			Created = DateTime.Now;
		}
	}
}
