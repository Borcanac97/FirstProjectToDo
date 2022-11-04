using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class ToDoItemController : ApiBaseController
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }


        [HttpGet]
        public async Task<ActionResult> GetToDoItemsByIdAsync(Guid id)
        {
            return Ok(_toDoItemService.GetToDoItemById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddToDoItemAsync([FromBody] ToDoItemDTO addToDoItemDTO)
        {
            return Ok(_toDoItemService.AddToDoItem(addToDoItemDTO));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateToDoItemAsync(ToDoItemDTO updateToDoItem)
        {
            return Ok(_toDoItemService.UpdateToDoItem(updateToDoItem));
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveToDoItemsAsync(Guid id)
        {
            return Ok(_toDoItemService.DeleteToDoItem(id));
        }

    }
}
