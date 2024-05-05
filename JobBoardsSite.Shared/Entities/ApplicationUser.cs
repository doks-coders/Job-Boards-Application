﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	public class ApplicationUser:IdentityUser<int>
	{
		
		public string? Industry { get; set; }

		public string? About { get; set; }
	
		
		
		public string? Name { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Country { get; set; }

		public string? UserType { get; set; }

		public string? City { get; set; }


		
		public string? Title { get; set; }

		public string? AverageSalary { get; set; }

		public string? SelectedSkills { get; set; }

		public string? ShortBio { get; set; }

		public ICollection<AppUserRole> UserRoles { get; set; }

		public ICollection<RecruiterJob> RecruiterJobs { get; set; }

		public bool ProfileCompleted { get; set; } = false;

	}
}
