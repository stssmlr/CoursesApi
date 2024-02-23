using CoursesApi.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var ip = await _usersService.GetAll();
            return Ok(ip);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int Id)
        {
            var ip = await _usersService.Get(Id);
            return Ok(ip);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var ip = await _usersService.Delete(Id);
            return Ok(ip);
        }
    }
}
