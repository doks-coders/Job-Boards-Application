using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Repositories
{
	public class UnitOfWork:IUnitOfWork
	{
		public IJobRepository Jobs { get; }
		public IAppUserRepository Users { get; }
		public IApplicantJobApplicationRepository ApplicantJobApplications { get; }

		private readonly AppIdentityDbContext _db;
		public UnitOfWork(AppIdentityDbContext db)
		{
			Jobs = new JobRepository(db);
			Users = new AppUserRepository(db);
			ApplicantJobApplications = new ApplicantJobApplicationRepository(db);
			_db = db;
		}

		public async Task<bool> SaveChanges()
		{
			return  0 < await _db.SaveChangesAsync() ;
		} 
	}
}
