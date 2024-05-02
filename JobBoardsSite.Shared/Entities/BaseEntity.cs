using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	public class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		public DateTime Created { get; set; } 

		public DateTime Updated { get; set; }

		public BaseEntity()
		{
			if(Created != Updated)
			{
				Updated = DateTime.Now;
			}
			else
			{
				Created = DateTime.Now;
			}
		}
	}
}
