using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Repositories.Interfaces
{
	public interface IRepository<T> where T : class 
	{
		Task<T> GetOne(Expression<Func<T, bool>> query, string includeProperties);

		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query, string includeProperties);


		Task AddItem(T entity);


		Task AddItem(IEnumerable<T> entities);
		


	}

}
