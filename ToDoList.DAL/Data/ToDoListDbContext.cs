using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Configuration;
using ToDoList.DAL.Entity;

namespace ToDoList.DAL.Data
{
   public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions options) : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }
    }
}
