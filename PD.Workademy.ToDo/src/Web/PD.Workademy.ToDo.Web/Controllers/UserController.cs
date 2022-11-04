using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        public async Task<ActionResult> GetUserByIdAsync(Guid id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(UserDTO user)
        {
            return Ok(_userService.AddUser(user));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(UserDTO updateUser)
        {
            return Ok(_userService.UpdateUser(updateUser));
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUsersAsync(Guid id)
        {
            return Ok(_userService.DeleteUser(id));
        }


    }
}
