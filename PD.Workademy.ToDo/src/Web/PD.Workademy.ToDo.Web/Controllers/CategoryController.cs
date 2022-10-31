using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Web.Controllers
{

    public class CategoryController : ApiBaseController
    {

        [HttpGet]
        public async Task<ActionResult> GetAllCategoresAsync()
        {
            List<CategoryDTO> categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),

            };
            return Ok(categoryDTOs);
            
       
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CategoryDTO request)
        {
            List<CategoryDTO> categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
            };
            categoryDTOs.Add(request);
            return Ok(categoryDTOs);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategoryByIdAsync(Guid id,CategoryDTO updatedCategory)
        {
            List<CategoryDTO> categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
            };
            CategoryDTO categoryDTO = categoryDTOs.Find(x => x.Id == id);
            categoryDTO.Id = updatedCategory.Id;
            categoryDTO.Name = updatedCategory.Name;
            return Ok(categoryDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveCategoresAsync( Guid id)
        {
            List<CategoryDTO> categoryDTOs = new()
            {
                new CategoryDTO(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Easy"),
                new CategoryDTO(new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"), "Medium"),
                new CategoryDTO(new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"), "Hard"),
            };
            CategoryDTO categoryToDelete = categoryDTOs.Find(x => x.Id == id);
            categoryDTOs.Remove(categoryToDelete);
            return Ok(categoryDTOs);
        }

    }
}
