using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;

namespace JobBoardsSite.Infrastructure.Repositories;

public class ApplicantJobApplicationRepository : Repository<ApplicantJobApplication>, IApplicantJobApplicationRepository
{
	public ApplicantJobApplicationRepository(AppIdentityDbContext db) : base(db)
	{
	}
}
