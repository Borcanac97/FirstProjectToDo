using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpGet("/Users")]
        public async Task<ActionResult> GetUsersAsync()
        {
            var users = _userService.GetUsers().Select(user => new UserDTO(user.Id, user.FirstName, user.LastName));
            return Ok(users);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllUsersAsync(Guid id)
        {
            List<UserDTO> userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            UserDTO getUser = userDTOs.Find(x => x.Id == id);
            return Ok(getUser);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(UserDTO user)
        {
            List<UserDTO> userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            userDTOs.Add(user);
            return Ok(userDTOs);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(Guid id,UserDTO updateUser)
        {
            List<UserDTO> userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            UserDTO userDTO = userDTOs.Find(x => x.Id == id);
            userDTO.Id = updateUser.Id;
            userDTO.FirstName= updateUser.FirstName;
            userDTO.LastName= updateUser.LastName;
            return Ok(userDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUsersAsync(Guid id)
        {
            List<UserDTO> userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            UserDTO userDTO = userDTOs.Find(x => x.Id == id);
            userDTOs.Remove(userDTO);
            return Ok(userDTOs);
        }


    }
}
