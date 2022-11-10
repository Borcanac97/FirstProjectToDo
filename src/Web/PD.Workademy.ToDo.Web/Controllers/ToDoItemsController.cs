using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class ToDoItemsController : ApiBaseController
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly ILogger<ToDoItemsController> _logger;

        public ToDoItemsController(IToDoItemService toDoItemService, ILogger<ToDoItemsController> logger)
        {
            _toDoItemService = toDoItemService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetToDoItemsAsync()
        {
            _logger.LogInformation("Todo todo test");
            return Ok(_toDoItemService.GetToDoItems());
        }
    }
}


