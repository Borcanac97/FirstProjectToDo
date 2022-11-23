using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.DTOModels;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;
using PD.Workademy.ToDo.Infrastructure.Persistance;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class ToDoItemsController : ApiBaseController
    {
        private readonly ILogger<ToDoItemController> _logger;
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemsController(IToDoItemService toDoItemService, ILogger<ToDoItemController> logger)
        {
            _toDoItemService = toDoItemService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetToDoItemsAsync([FromQuery] FilterDTO filter)
        {
            _logger.LogInformation("Get TodoItems");
            return Ok(_toDoItemService.GetToDoByFilter(filter));
        }
    }
}


