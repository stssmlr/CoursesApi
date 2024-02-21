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
            var author = await _authorService.Get(Id);
            if (author == null)
            {
                return Ok("Author Is not Found");
            }
            return Ok(author);
        }
        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByCategory(string email)
        {
            var res = await _authorService.GetByEmail(email);
            if (res == null)
            {
                return Ok("Email Is not Found");
            }
            return Ok(res);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Author model)
        {
            var res = await _authorService.Insert(model);
            return Ok(res);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Author model)
        {
            var res = await _authorService.Update(model);
            return Ok(res);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _authorService.Delete(Id);
            return Ok(res);
        }
    }
}
