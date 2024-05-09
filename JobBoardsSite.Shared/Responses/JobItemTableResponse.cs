using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Responses
{
	public class JobItemTableResponse
	{
		public int JobId { get; set; }	
		public string JobTitle { get; set; }
		public string ContactEmail { get; set; }
		public string Salary { get; set; }	
	}
}
