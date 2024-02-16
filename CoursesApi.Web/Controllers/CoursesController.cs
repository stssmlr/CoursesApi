using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
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
            var news = await _coursesService.Get(Id);
            return Ok(news);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertCoursesDto model)
        {
            var userExists = await _coursesService.Get(model.Id);
            if (userExists != null)
            {
                return Ok("This Course Already Exists!");
                
            }
            else
            {
                await _coursesService.Insert(model);
                return Ok();
            }
            
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Courses model)
        {
            await _coursesService.Update(model);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _coursesService.Delete(Id);
            return Ok();
        }
        [HttpPost("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id) 
        {
            var news = await _coursesService.GetByCategory(id);
            return Ok(news);
        }
        [HttpPost("GetByAuthor")]
        public async Task<IActionResult> GetByAuthor(int id)
        {
            var news = await _coursesService.GetByAuthor(id);
            return Ok(news);
        }
    }
    
}
