using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Web.ApiModels;


namespace PD.Workademy.ToDo.Web.Controllers
{

    public class CategoryController : ApiBaseController
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/Categories")]
        public async Task<ActionResult> GetCategoresAsync()
        {

            return Ok(_categoryService.GetCategories());

        }

        [HttpGet]
        public async Task<ActionResult> GetCategoryByIdAsync(Guid id)
        { 
            return Ok(_categoryService.GetCategoryById(id));
       
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CategoryDTO request)
        {
            return Ok(_categoryService.AddCategory(request));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategoryByIdAsync(Guid id,CategoryDTO updatedCategory)
        { 
            return Ok(_categoryService.UpdateCategory(id,updatedCategory));
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveCategoresAsync( Guid id)
        {
            return Ok(_categoryService.DeleteCategory(id));
        }

    }
}
