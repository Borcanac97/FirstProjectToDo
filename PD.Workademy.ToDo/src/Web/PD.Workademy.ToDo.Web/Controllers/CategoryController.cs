using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ApiBaseController
    {

        [HttpGet]
        public async Task<ActionResult> GetAllCategoresAsync()
        {
            List<CategoryDTO> _categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),

            };
            return Ok(_categoryDTOs);
            
       
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CategoryDTO request)
        {
            List<CategoryDTO> _categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
            };
            _categoryDTOs.Add(request);
            return Ok(_categoryDTOs);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategoryByIdAsync(Guid id,CategoryDTO updatedCategory)
        {
            List<CategoryDTO> _categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
            };
            CategoryDTO _categoryDTO = _categoryDTOs.Find(x => x.Id == id);
            _categoryDTO.Id = updatedCategory.Id;
            _categoryDTO.Name = updatedCategory.Name;
            return Ok(_categoryDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveCategoresAsync( Guid id)
        {
            List<CategoryDTO> _categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
            };
            CategoryDTO _categoryToDelete = _categoryDTOs.Find(x => x.Id == id);
            _categoryDTOs.Remove(_categoryToDelete);
            return Ok(_categoryDTOs);
        }

    }
}
