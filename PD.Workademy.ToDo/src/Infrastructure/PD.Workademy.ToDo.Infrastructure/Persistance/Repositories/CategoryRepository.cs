using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;

namespace PD.Workademy.ToDo.Infrastructure.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Category AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return _dbContext.Categories.FirstOrDefault(x => x.Id == category.Id);
        }

        public Category DeleteCategory(Guid id)
        {

            Category category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            _dbContext.SaveChanges();
            return _dbContext.Categories;
        }

        public Category GetCategoryById(Guid id)
        {
            _dbContext.SaveChanges();
            return _dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category UpdateCategory(Guid id, Category category)
        {
            var categoryUpdate = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            categoryUpdate.Id = category.Id;
            categoryUpdate.Name = category.Name;
            _dbContext.SaveChanges();
            return categoryUpdate;
        }
    }
}
