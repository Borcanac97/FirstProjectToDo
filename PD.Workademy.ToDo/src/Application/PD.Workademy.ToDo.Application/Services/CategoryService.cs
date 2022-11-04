using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.Services
{


    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDTO AddCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category(categoryDTO.Id, categoryDTO.Name);

            Category savedCategory = _categoryRepository.AddCategory(category);

            CategoryDTO _categoryDTO = new CategoryDTO(savedCategory.Id, savedCategory.Name);

            return _categoryDTO;

        }

        public CategoryDTO DeleteCategory(Guid id)
        {
            Category categoryToDelete = _categoryRepository.DeleteCategory(id);
            CategoryDTO categoryDTO = new(categoryToDelete.Id, categoryToDelete.Name);
            return categoryDTO;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return categories.Select(x => new CategoryDTO(x.Id, x.Name));
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            CategoryDTO categoryDTO = new(category.Id, category.Name);
            return categoryDTO;
        }

        public CategoryDTO UpdateCategory(CategoryDTO category)
        {
            Category categoryUpdate = new(category.Id, category.Name);
            _categoryRepository.UpdateCategory(categoryUpdate);
            CategoryDTO categoryDTO = new(category.Id, category.Name);
            return categoryDTO;
        }
    }

}
