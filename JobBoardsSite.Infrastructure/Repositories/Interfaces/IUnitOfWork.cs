using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		IJobRepository Jobs { get; }
		IAppUserRepository Users { get; }
		IApplicantJobApplicationRepository ApplicantJobApplications { get; }
		Task<bool> SaveChanges();
	}
}
