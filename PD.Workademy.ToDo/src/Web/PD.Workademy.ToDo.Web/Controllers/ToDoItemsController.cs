using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    [ApiController]
    public class ToDoItemsController : ApiBaseController
    {
       
        [HttpGet]
        public async Task<ActionResult> GetAllToDoItemsAsync()
        {
            List<ToDoItemDTO> _toDoItemDTO = new()
            {
                new ToDoItemDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Create MSSQL","It`s Easy", true,
                                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"), "Easy"),
                                new UserDTO( new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic")
                                ),
                new ToDoItemDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Create MSSQL","It`s Hard", true,
                                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Hard"),
                                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic")
                                ),
                new ToDoItemDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Create MSSQL","It`s Medium", false,
                                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Medium"),
                                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
                                )
            };
            return Ok(_toDoItemDTO);
        }

        
    }
}


