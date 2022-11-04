using PD.Workademy.ToDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository
{
    public interface ICategoryRepository
    {

        IEnumerable<Category> GetCategories();

        Category GetCategoryById(Guid id);

        Category UpdateCategory(Guid id, Category category);

        Category DeleteCategory(Guid id);

        Category AddCategory(Category category);

    }
}
