using PD.Workademy.ToDo.Domain.Entities;

namespace PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository
{
    public interface IToDoItemRepository
    {

        IEnumerable<ToDoItem> GetToDoItems();
        IEnumerable<ToDoItem> GetToDoByFilter(string search, string sortBy, int page, int perPage);

        ToDoItem GetToDoItemById(Guid id);

        ToDoItem UpdateToDoItem(ToDoItem toDoItem);

        ToDoItem DeleteToDoItem(Guid id);

        ToDoItem AddToDoItem(ToDoItem toDoItem);
    }
}
