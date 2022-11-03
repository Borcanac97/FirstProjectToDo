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
        public static List<Category> categories = new()
        {
             new Category(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
             new Category(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
             new Category(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
        };
        public Category AddCategory(Category category)
        {
            categories.Add(category);
            return categories.Find(x=>x.Id==category.Id);
        }

        public Category DeleteCategory(Guid id)
        {

            categories.Remove(categories.Find(x=>x.Id==id));
            Category category = categories.Find(x=>x.Id==id);
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
           return categories;
        }

        public Category GetCategoryById(Guid id)
        {
            return categories.Find(x => x.Id == id);
        }

        public Category UpdateCategory(Guid id, Category category)
        {
            var categoryUpdate=categories.Find(x=>x.Id==id);
            categoryUpdate.Id=category.Id;
            categoryUpdate.Name=category.Name;
            return categoryUpdate;
        }
    }
}
