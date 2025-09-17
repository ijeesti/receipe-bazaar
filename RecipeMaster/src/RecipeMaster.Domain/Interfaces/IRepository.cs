using RecipeMaster.Domain.Entities;
using System.Linq.Expressions;

namespace RecipeMaster.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity//class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
     Task<IEnumerable<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);

    Task<int> SaveChangesAsync(); // explicit commit
}