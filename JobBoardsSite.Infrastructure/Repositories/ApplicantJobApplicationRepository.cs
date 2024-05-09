using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Repositories
{
	public class ApplicantJobApplicationRepository : Repository<ApplicantJobApplication>, IApplicantJobApplicationRepository
	{
		public ApplicantJobApplicationRepository(AppIdentityDbContext db) : base(db)
		{
		}
	}
}
