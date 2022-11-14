using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.DTOModels;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Infrastructure.Persistance;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class ToDoItemsController : ApiBaseController
    {
        private readonly IToDoItemService _toDoItemService;
        public ToDoItemsController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }
        [HttpGet]
        public async Task<ActionResult> GetToDoItemsAsync()
        {

            return Ok(_toDoItemService.GetToDoItems());
        }
    }
}


