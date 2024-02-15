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
    }
    
}
