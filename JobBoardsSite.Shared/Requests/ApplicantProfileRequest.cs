using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{
	
		public class ApplicantProfileRequest
		{
			[Required]
			public string Name { get; set; }

			[Required]
			[Phone]
			public string PhoneNumber { get; set; }

			[Required]
			public string Title { get; set; }

			[Required]
			public string Country { get; set; }

			[Required]
			public string AverageSalary { get; set; }


			[Required]
			public string SelectedSkills { get; set; }

			[Required]
			public string City { get; set; }

			[Required]
			public string ShortBio { get; set; }


			public List<WorkExperienceRequest> WorkExperiences { get; set; } = new();

		
	}
}
