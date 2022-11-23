using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;

namespace PD.Workademy.ToDo.Web.Controllers
{
    public class CategoriesController : ApiBaseController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoresAsync()
        {
            _logger.LogInformation("GetCategories");
            return Ok(_categoryService.GetCategories());
        }
    }
}
