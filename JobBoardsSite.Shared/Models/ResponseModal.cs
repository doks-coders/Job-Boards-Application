
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Models
{
	public class ResponseModal
	{
		public string Message { get; set; }
		public bool isSuccess { get; set; } = true;
		public object Data { get; set; }
	}
}
