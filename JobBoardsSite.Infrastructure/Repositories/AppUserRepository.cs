using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;

namespace JobBoardsSite.Infrastructure.Repositories;

public class AppUserRepository : Repository<ApplicationUser>, IAppUserRepository
{
	public AppUserRepository(AppIdentityDbContext db) : base(db)
	{
	}


}
