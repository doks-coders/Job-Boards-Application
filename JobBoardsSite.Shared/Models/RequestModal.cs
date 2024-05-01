using JobBoardsSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Models
{
	public class RequestModal
	{
		public ApiVerbs Method { get; set; }
		public string Url { get; set; }
		public object Data { get; set; }

	}
}
