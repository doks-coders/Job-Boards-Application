﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{
	public class CreateJobRequest
	{
		public string JobTitle { get; set; }


		public string About { get; set; }


		public string Salary { get; set; }


		public string Responsiblities { get; set; }


		public string Qualifications { get; set; }


		public string SelectedSkills { get; set; }


		public string JobFunction { get; set; }


		public string ContactEmail { get; set; }
	}
}