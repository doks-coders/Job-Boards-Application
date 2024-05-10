using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobBoardsSite.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly DbSet<T> _db;
	public Repository(AppIdentityDbContext db)
	{
		_db = db.Set<T>();
	}

	public async Task<T> GetOne(Expression<Func<T, bool>> query, string? includeProperties = null)
	{
		var q = _db.AsQueryable();
		q = IncludeFields(q, includeProperties);
		return await q.FirstOrDefaultAsync(query);
	}




	public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query, string? includeProperties = null)
	{
		var q = _db.AsQueryable();
		q = IncludeFields(q, includeProperties);
		return await q.Where(query).ToListAsync();
	}

	public async Task<PaginationResponse> GetPagination(PaginationRequest request, Expression<Func<T, bool>> query, string? includeProperties = null)
	{
		var totalNumber = await _db.Where(query).CountAsync();

		var limit = request.PageLimit;
		var page = request.PageNumber;
		var skipValue = limit * (page - 1);


		var totalPages = Math.Ceiling(totalNumber / (decimal)limit);


		var q = _db.AsQueryable();
		q = IncludeFields(q, includeProperties);
		var pagedValues = q.Where(query).Skip(skipValue).Take(limit).ToList();

		return new PaginationResponse()
		{
			Items = pagedValues,
			PageNumber = page,
			TotalPages = (int)totalPages
		};

	}

	public async Task AddItem(T entity)
	{
		await _db.AddAsync(entity);
	}

	public async Task AddItem(IEnumerable<T> entities)
	{
		await _db.AddRangeAsync(entities);
	}

	private IQueryable<T> IncludeFields(IQueryable<T> q, string includeProperties)
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
