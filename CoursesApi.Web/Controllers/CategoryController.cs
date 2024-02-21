using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using static CoursesApi.Core.Entities.Specifications.CoursesSpecification;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var news = await _categoryService.GetAll();
            return Ok(news);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int Id)
        {
            var category = await _categoryService.Get(Id);
            if (category == null)
            {
                return Ok("Category Is not Found");
            }
            return Ok(category);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Category model)
        {
            var res = await _categoryService.Insert(model);
            return Ok(res);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Category model)
        {
            var res = await _categoryService.Update(model);
            return Ok(res);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _categoryService.Delete(Id);
            return Ok(res);
        }
    }
}
