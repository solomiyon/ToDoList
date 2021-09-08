using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoList.DAL.Repository;

namespace ToDoList.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        private DbContext Context { get; }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(Context.Set<TEntity>(), Context);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = Context.ChangeTracker
                .Entries();

            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
