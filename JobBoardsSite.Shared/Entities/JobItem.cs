using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	public class JobItem:BaseEntity
	{
		public int RecruiterId { get; set; }

		[ForeignKey(nameof(RecruiterId))]
		public ApplicationUser Recruiter { get; set; }
		
		public string JobTitle { get; set; }

		
		public string About { get; set; }

	
		public string Salary { get; set; }

		
		public string Responsiblities { get; set; }

		
		public string Qualifications { get; set; }

		
		public string SelectedSkills { get; set; }


		public string JobFunction { get; set; }


		public string WorkLocationType { get; set; }


		public string WorkType { get; set; }


		public string ContactEmail { get; set; }

		
		public ICollection<RecruiterJob> RecruiterJobs { get; set; }

	}

}
