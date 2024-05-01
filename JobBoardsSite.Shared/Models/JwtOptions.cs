﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Models
{
	public class JwtOptions
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
    }
	
}
