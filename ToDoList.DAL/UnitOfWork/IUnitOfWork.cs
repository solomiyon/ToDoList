using System.Threading.Tasks;
using ToDoList.DAL.Repository;

namespace ToDoList.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
