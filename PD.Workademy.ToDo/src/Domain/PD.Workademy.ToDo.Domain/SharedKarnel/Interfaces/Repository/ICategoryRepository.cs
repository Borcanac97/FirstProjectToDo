using PD.Workademy.ToDo.Domain.Entities;

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
