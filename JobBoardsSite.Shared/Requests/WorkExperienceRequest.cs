using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{
	public class WorkExperienceRequest
	{
		
			[Required]
			public string Location { get; set; }

			[Required]
			public string Company { get; set; }

			[Required]
			public string Title { get; set; }
			[Required]
			public string Duration { get; set; }
			[Required]
			public string Summary { get; set; }

		
	}
}
