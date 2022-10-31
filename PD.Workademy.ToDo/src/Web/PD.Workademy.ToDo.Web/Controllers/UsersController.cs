using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            List<UserDTO> _userDTOs = new()
            {
                new UserDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new UserDTO( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new UserDTO( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };
            return Ok(_userDTOs);
        }
    }
}
