using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	public class ApplicantJobApplication
	{
		public int ApplicantId { get; set; }

		[ForeignKey(nameof(ApplicantId))]
		public ApplicationUser Applicant { get; set; }

		public int JobId { get; set; }
		public DateTime DateApplied { get; set; } = DateTime.Now;

		public int RecruiterId { get; set; }

		[ForeignKey(nameof(RecruiterId))]
		public ApplicationUser Recruiter { get; set; }

		public bool Accepted { get; set; } = false;
	}
}
