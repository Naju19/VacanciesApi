using System.Linq.Expressions;

namespace Vacancies.Infrastructure.Repositories
{
    public interface IGenericRepository<T> 
    {
        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter, List<string>? includes = null);
        Task<T> GetByIdAsync(object id);
        Task<T> CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        
    }
}
