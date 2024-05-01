using JobBoardsSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Models
{
	public class CustomException:Exception
	{
		public CustomException(string exception):base(exception)
		{

		}
		public CustomException(ErrorCodes exception) : base(exception.ToString())
		{

		}
		public CustomException(string[]exception) : base(string.Join(", ",exception))
		{

		}
	}
}
