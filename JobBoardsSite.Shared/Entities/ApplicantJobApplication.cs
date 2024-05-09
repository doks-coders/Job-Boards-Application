using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Entities
{
	public class ApplicantJobApplication
	{
		[Key]
		public int Id { get; set; }

		public int ApplicantId { get; set; }

		[ForeignKey(nameof(ApplicantId))]
		[DeleteBehavior(DeleteBehavior.NoAction)]
		public ApplicationUser Applicant { get; set; }

		public int JobId { get; set; }
		[ForeignKey(nameof(JobId))]
		[DeleteBehavior(DeleteBehavior.NoAction)]
		public JobItem Job { get; set; }

		public DateTime DateApplied { get; set; } = DateTime.Now;

		public int RecruiterId { get; set; }

		[ForeignKey(nameof(RecruiterId))]
		[DeleteBehavior(DeleteBehavior.NoAction)]
		public ApplicationUser Recruiter { get; set; }

		public bool Accepted { get; set; } = false;
	}
}
