using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class UsersController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsersAsync()
        {
            return Ok(_userService.GetUsers());
        }
    }
}
