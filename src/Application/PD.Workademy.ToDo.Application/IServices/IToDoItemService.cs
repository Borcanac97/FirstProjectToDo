using PD.Workademy.ToDo.Application.DTOModels;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface IToDoItemService
    {
        IEnumerable<ToDoItemDTO> GetToDoItems();
        GetFilterDTO GetToDoByFilter(FilterDTO _filterDTO);
        ToDoItemDTO GetToDoItemById(Guid id);
        ToDoItemDTO UpdateToDoItem(UpdateToDoDTO updatetoDoDTO);
        ToDoItemDTO DeleteToDoItem(Guid id);
        ToDoItemDTO AddToDoItem(AddToDoDTO toDoItemDTO);
    }
}
