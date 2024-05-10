using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;

namespace JobBoardsSite.Infrastructure.Repositories;

public class JobRepository : Repository<JobItem>, IJobRepository
{
	public JobRepository(AppIdentityDbContext db) : base(db)
	{
	}
}
