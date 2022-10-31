using Microsoft.EntityFrameworkCore;
using PD.Workademy.ToDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Infrastructure.Persistance
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext() { }

        public DbSet<User> Users  { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Todo;Trusted_Connection=true;");
        }

    }
}
