using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using Microsoft.AspNetCore.Mvc;

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
            var news = await _categoryService.Get(Id);
            return Ok(news);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Category model)
        {
            await _categoryService.Insert(model);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Category model)
        {
            await _categoryService.Update(model);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _categoryService.Delete(Id);
            return Ok();
        }
    }
}
