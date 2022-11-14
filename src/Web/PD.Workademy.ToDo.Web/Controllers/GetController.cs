using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.DTOModels;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ApiBaseController
    {
        [HttpGet ("/title")]
        public async Task<ActionResult> GetToDoItems([FromQuery] FilterDTO request)
        {
            return Ok();
        }
    }
}
