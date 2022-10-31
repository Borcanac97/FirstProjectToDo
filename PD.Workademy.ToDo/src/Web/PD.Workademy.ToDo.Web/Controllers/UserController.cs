using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiBaseController
    {

        [HttpGet]
        public async Task<ActionResult> GetAllUsersAsync(Guid id)
        {
            List<UserDTO> _userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            UserDTO _getUser = _userDTOs.Find(x => x.Id == id);
            return Ok(_getUser);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(UserDTO _user)
        {
            List<UserDTO> _userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            _userDTOs.Add(_user);
            return Ok(_userDTOs);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(Guid id,UserDTO _updateUser)
        {
            List<UserDTO> _userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            UserDTO _userDTO = _userDTOs.Find(x => x.Id == id);
            _userDTO.Id = _updateUser.Id;
            _userDTO.FirstName= _updateUser.FirstName;
            _userDTO.LastName= _updateUser.LastName;
            return Ok(_userDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUsersAsync(Guid id)
        {
            List<UserDTO> _userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            UserDTO _userDTO = _userDTOs.Find(x => x.Id == id);
            _userDTOs.Remove(_userDTO);
            return Ok(_userDTOs);
        }


    }
}
