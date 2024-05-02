using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbSet<T> _db;
		public Repository(AppIdentityDbContext db)
		{
			_db = db.Set<T>();
		}

		public async Task<T> GetOne(Expression<Func<T, bool>> query, string includeProperties)
		{
			var q = _db.AsQueryable();
			q = IncludeFields(q, includeProperties);
			return await q.FirstOrDefaultAsync(query);
		}

		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query, string includeProperties)
		{
			var q = _db.AsQueryable();
			q = IncludeFields(q, includeProperties);
			return await q.Where(query).ToListAsync();
		}

		public async Task AddItem(T entity)
		{
			await _db.AddAsync(entity);
		}

		public async Task AddItem(IEnumerable<T> entities)
		{
			await _db.AddRangeAsync(entities);
		}

		private IQueryable<T> IncludeFields(IQueryable<T> q,string includeProperties)
		{
			if (!string.IsNullOrEmpty(includeProperties))
			{
				string[] props = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);

				foreach (string prop in props)
				{
					q = q.Include(prop);
				}
			}
			return q;
		}
	}
}
