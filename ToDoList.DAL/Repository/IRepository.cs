using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDoList.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> where);
    void Remove(T entity);
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
    }
}
