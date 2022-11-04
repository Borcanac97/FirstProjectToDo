using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface ICategoryService
    {

        IEnumerable<CategoryDTO> GetCategories();

        CategoryDTO GetCategoryById(Guid id);

        CategoryDTO UpdateCategory(CategoryDTO category);

        CategoryDTO DeleteCategory(Guid id);

        CategoryDTO AddCategory(CategoryDTO category);

    }
}