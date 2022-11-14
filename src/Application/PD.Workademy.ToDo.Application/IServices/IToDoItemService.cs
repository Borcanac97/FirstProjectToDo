using PD.Workademy.ToDo.Application.DTOModels;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface IToDoItemService
    {
        IEnumerable<ToDoItemDTO> GetToDoItems();
        IEnumerable<ToDoItemDTO> GetToDoByFilter(FilterDTO _filterDTO);
        ToDoItemDTO GetToDoItemById(Guid id);
        ToDoItemDTO UpdateToDoItem(ToDoItemDTO toDoItemDTO);
        ToDoItemDTO DeleteToDoItem(Guid id);
        ToDoItemDTO AddToDoItem(ToDoItemDTO toDoItemDTO);
    }
}
