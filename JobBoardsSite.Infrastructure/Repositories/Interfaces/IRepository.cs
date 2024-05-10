using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using System.Linq.Expressions;

namespace JobBoardsSite.Infrastructure.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
	Task<T> GetOne(Expression<Func<T, bool>> query, string? includeProperties = null);

	Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query, string? includeProperties = null);

	Task<PaginationResponse> GetPagination(PaginationRequest request, Expression<Func<T, bool>> query, string? includeProperties = null);

	Task AddItem(T entity);

	Task AddItem(IEnumerable<T> entities);



}
