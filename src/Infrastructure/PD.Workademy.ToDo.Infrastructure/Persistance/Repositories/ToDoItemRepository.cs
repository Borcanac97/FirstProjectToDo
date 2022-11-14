using Microsoft.EntityFrameworkCore;
using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;

namespace PD.Workademy.ToDo.Infrastructure.Persistance.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ToDoItemRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ToDoItem AddToDoItem(ToDoItem toDoItem)
        {
            _dbContext.Add(toDoItem);
            _dbContext.SaveChanges();
            return _dbContext.ToDoItems
                            .FirstOrDefault(x => x.Id == toDoItem.Id);
        }
        public ToDoItem DeleteToDoItem(Guid id)
        {
            ToDoItem toDoItem = _dbContext.ToDoItems
                        .Include(x => x.Category).Include(x => x.User)
                        .FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(toDoItem);
            _dbContext.SaveChanges();
            return toDoItem;
        }
        public IEnumerable<ToDoItem> GetToDoItems()
        {
            _dbContext.SaveChanges();
            return _dbContext.ToDoItems
                .Include(x => x.Category)
                .Include(x => x.User);
        }
        public ToDoItem GetToDoItemById(Guid id)
        {
            _dbContext.SaveChanges();
            return _dbContext.ToDoItems.Include(x => x.Category)
                                       .Include(x => x.User)
                                       .FirstOrDefault(x => x.Id == id);
        }
        public ToDoItem UpdateToDoItem(ToDoItem toDoItem)
        {
            var toDoItemUpdate = _dbContext.ToDoItems
                                .FirstOrDefault(x => x.Id == toDoItem.Id);
            toDoItemUpdate.Title = toDoItem.Title;
            toDoItemUpdate.Description = toDoItem.Description;
            toDoItemUpdate.ChangeStatus(toDoItem.IsDone);
            toDoItemUpdate.User = toDoItem.User;
            toDoItemUpdate.Category = toDoItem.Category;
            _dbContext.SaveChanges();
            return toDoItemUpdate;
        }

        public IEnumerable<ToDoItem> GetToDoByFilter(string search, string sortBy, int page, int perPage)
        {
            var toDoItems = _dbContext.ToDoItems.
                Include(x => x.Category)
                .Include(x => x.User)
                .Where(x => x.Title.Contains(search)
                         || x.Description.Contains(search)
                         || x.Category.Name.Contains(search)
                         || x.User.FirstName.Contains(search)
                         || x.User.LastName.Contains(search)
                         )
                .OrderBy(x => x[sortBy])
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();

            return toDoItems;
        }
    }
}
