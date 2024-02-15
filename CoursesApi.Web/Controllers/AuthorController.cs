using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var news = await _authorService.GetAll();
            return Ok(news);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int Id)
        {
            var news = await _authorService.Get(Id);
            return Ok(news);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Author model)
        {
            await _authorService.Insert(model);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Author model)
        {
            await _authorService.Update(model);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _authorService.Delete(Id);
            return Ok();
        }
    }
}
