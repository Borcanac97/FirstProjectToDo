using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Web.ApiModels;
using System;

namespace PD.Workademy.ToDo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetToDoItemsAsync(Guid id)
        {
            ToDoItemDTO _toDoItemDTO =
            new(
                    id,
                    "Learn .NET",
                    "U should learn this as soon as you can !",
                    false,
                    new CategoryDTO(new Guid("928f52a5-7517-4e67-8f08-a96a61e692ed"), "Easy"),
                    new UserDTO(
                        new Guid("205d51ef-3d82-4869-8842-e342e78e78db"),
                        "Nikola",
                        "Djokic"
                    )
                );
            return Ok(_toDoItemDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddToDoItemAsync([FromBody]ToDoItemDTO _addToDoItemDTO)
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
            _toDoItemDTO.Add(_addToDoItemDTO);
            return Ok(_toDoItemDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateToDoItemAsync(Guid id,ToDoItemDTO _updateToDoItem)
        {
            List<ToDoItemDTO> _toDoItemDTOs = new()
            {   
                new ToDoItemDTO(
                    new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Create MSSQL","It`s Easy", true,
                                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"), "Easy"),
                                new UserDTO( new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic")
                                ),
                 new ToDoItemDTO(
                     new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Create MSSQL","It`s Hard", true,
                                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Hard"),
                                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic")
                                ),

                  new ToDoItemDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Create MSSQL","It`s Medium", false,
                                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Medium"),
                                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
                                )
                
            };
            ToDoItemDTO _toDoItemDTO = _toDoItemDTOs.Find(x => x.Id == id);
            _toDoItemDTO.Id = _updateToDoItem.Id;
            _toDoItemDTO.Title=_updateToDoItem.Title;
            _toDoItemDTO.Description=_updateToDoItem.Description;
            _toDoItemDTO.Category = _updateToDoItem.Category;
            _toDoItemDTO.User = _updateToDoItem.User;
            return Ok(_toDoItemDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveToDoItemsAsync(Guid id)
        {
            List<ToDoItemDTO> _toDoItemDTOs = new()
            {
                new ToDoItemDTO(
                    new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Create MSSQL","It`s Easy", true,
                                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"), "Easy"),
                                new UserDTO( new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic")
                                ),
                 new ToDoItemDTO(
                     new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Create MSSQL","It`s Hard", true,
                                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Hard"),
                                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic")
                                ),

                  new ToDoItemDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Create MSSQL","It`s Medium", false,
                                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Medium"),
                                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
                                )

            };
            ToDoItemDTO _DeleteToDoItem = _toDoItemDTOs.Find(x => x.Id == id);
            _toDoItemDTOs.Remove(_DeleteToDoItem);
            return Ok(_toDoItemDTOs);
        }

    }
}
