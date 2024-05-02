using JobBoardsSite.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Repositories.Interfaces
{
	public interface IJobRepository:IRepository<JobItem>
	{
	}
}
