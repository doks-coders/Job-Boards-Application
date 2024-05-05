using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	
		public class WorkExperience
		{
			public string Location { get; set; }

			public string Company { get; set; }

			public string Title { get; set; }
			public string Duration { get; set; }
			public string Summary { get; set; }

		}
	
}
