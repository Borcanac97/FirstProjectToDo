using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Infrastructure.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Category DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Guid id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
