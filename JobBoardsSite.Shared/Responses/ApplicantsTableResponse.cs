using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Responses
{
	public class ApplicantsTableResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Salary { get; set; }
		public string JobTitle { get; set; }
	}
}
