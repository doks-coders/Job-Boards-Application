﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{

	public class PaginationRequest
	{
		public int PageNumber { get; set; }
		public int PageLimit { get; set; } = 3;

	}
}
