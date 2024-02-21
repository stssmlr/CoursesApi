using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using CoursesApi.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var news = await _coursesService.GetAll();
            return Ok(news);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int Id)
        {
            var course = await _coursesService.Get(Id);
            if (course == null)
            {
                return Ok("Course Is not Found");
            }
            return Ok(course);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertCoursesDto model)
        {
            var info = await _coursesService.Insert(model);
            return Ok(info);

        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(InsertCoursesDto model)
        {
            var info = await _coursesService.Update(model);
            return Ok(info);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _coursesService.Delete(Id);
            return Ok(res);
        }
        [HttpPost("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id) 
        {
            var getc = await _coursesService.GetByCategory(id);
            if (getc == null)
            {
                return Ok("Category Is not Found");
            }
            return Ok(getc);
        }
        [HttpPost("GetByAuthor")]
        public async Task<IActionResult> GetByAuthor(int id)
        {
            var geta = await _coursesService.GetByAuthor(id);
            if (geta == null)
            {
                return Ok("Author Is not Found");
            }
            return Ok(geta);
        }

    }
    
}
