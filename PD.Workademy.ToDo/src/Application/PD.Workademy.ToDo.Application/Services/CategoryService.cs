using Microsoft.VisualBasic;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Web.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.Services
{


    public class CategoryService : ICategoryService
    {
       public static List<Category> categories = new()
        {
            new Category(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
            new Category(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
            new Category(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
        
        };

        public CategoryDTO AddCategory(CategoryDTO category)
        {
            Category _category = new(category.Id, category.Name);
            categories.Add(_category);
            return category;
        }

        public CategoryDTO DeleteCategory(Guid id)
        {
            Category category = categories.Find(x => x.Id == id);
            CategoryDTO categoryDTO = new(category.Id, category.Name);
            categories.Remove(category);
            return categoryDTO;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return categories.Select(x => new CategoryDTO(x.Id, x.Name));
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            Category category = categories.Find(x => x.Id == id);
            CategoryDTO categoryDTO = new(category.Id, category.Name);
            return categoryDTO;
        }

        public CategoryDTO UpdateCategory(Guid id, CategoryDTO category)
        {
            Category _category = categories.Find(x => x.Id == id);
            _category.Id = category.Id;
            _category.Name=category.Name;
            return category;
        }
    }

}
