using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;
using PD.Workademy.ToDo.Web.ApiModels;
using System;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class ToDoItemController : ApiBaseController
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
           _toDoItemService=toDoItemService;
        }

        [HttpGet("/ToDos")]
        public async Task<ActionResult> GetToDoItemsAsync()
        { 
            var toDos = _toDoItemService.GetItems().Select(todo => new ToDoItemDTO(todo.Id, todo.Title, todo.Description, todo.IsDone,
                 new CategoryDTO(todo.Category.Id, todo.Category.Name), new UserDTO(todo.User.Id, todo.User.FirstName, todo.User.LastName)));
            
            return Ok(toDos);
        }

        [HttpGet]
        public async Task<ActionResult> GetToDoItemsAsync(Guid id)
        {
            ToDoItemDTO toDoItemDTO =
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
            return Ok(toDoItemDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddToDoItemAsync([FromBody]ToDoItemDTO addToDoItemDTO)
        {
            List<ToDoItemDTO> toDoItemDTO = new()
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
            toDoItemDTO.Add(addToDoItemDTO);
            return Ok(toDoItemDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateToDoItemAsync(Guid id,ToDoItemDTO updateToDoItem)
        {
            List<ToDoItemDTO> toDoItemDTOs = new()
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
            ToDoItemDTO toDoItemDTO = toDoItemDTOs.Find(x => x.Id == id);
            toDoItemDTO.Id = updateToDoItem.Id;
            toDoItemDTO.Title=updateToDoItem.Title;
            toDoItemDTO.Description=updateToDoItem.Description;
            toDoItemDTO.Category = updateToDoItem.Category;
            toDoItemDTO.User = updateToDoItem.User;
            return Ok(toDoItemDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveToDoItemsAsync(Guid id)
        {
            List<ToDoItemDTO> toDoItemDTOs = new()
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
            ToDoItemDTO deleteToDoItem = toDoItemDTOs.Find(x => x.Id == id);
            toDoItemDTOs.Remove(deleteToDoItem);
            return Ok(toDoItemDTOs);
        }

    }
}
