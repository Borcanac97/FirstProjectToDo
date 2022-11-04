using Microsoft.EntityFrameworkCore;
using PD.Workademy.ToDo.Domain.Entities;

namespace PD.Workademy.ToDo.Infrastructure.Persistance
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .HasOne(b => b.Category)
                .WithMany(a => a.toDoItems)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
