using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;

namespace PD.Workademy.ToDo.Web.Controllers
{

    public class CategoriesController : ApiBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<ActionResult> GetCategoresAsync()
        {

            return Ok(_categoryService.GetCategories());

        }


    }
}
