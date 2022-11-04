using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface IToDoItemService
    {
        IEnumerable<ToDoItemDTO> GetToDoItems();

        ToDoItemDTO GetToDoItemById(Guid id);

        ToDoItemDTO UpdateToDoItem(ToDoItemDTO toDoItemDTO);

        ToDoItemDTO DeleteToDoItem(Guid id);

        ToDoItemDTO AddToDoItem(ToDoItemDTO toDoItemDTO);
    }
}
