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
        private readonly IUsersService _usersService;

        public CoursesController(ICoursesService coursesService, IUsersService usersService)
        {
            _coursesService = coursesService;
            _usersService = usersService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Users user = new Users()
            {
                IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                WhatRequest = "GetAll",
                Browser = "Course",
                VisitTime = DateTime.Now
            };
            await _usersService.Insert(user);
            var course = await _coursesService.GetAll();
            return Ok(course);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int Id)
        {
            Users user = new Users()
            {
                IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                WhatRequest = "Get",
                Browser = HttpContext.WebSockets.ToString(),
                VisitTime = DateTime.Now
            };
            await _usersService.Insert(user);
            var course = await _coursesService.Get(Id);
            return Ok(course);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertCoursesDto model)
        {
            Users user = new Users()
            {
                IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                WhatRequest = "Insert",
                Browser = HttpContext.WebSockets.ToString(),
                VisitTime = DateTime.Now
            };
            await _usersService.Insert(user);
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
            Users user = new Users()
            {
                IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                WhatRequest = "Delete",
                Browser = HttpContext.WebSockets.ToString(),
                VisitTime = DateTime.Now
            };
            await _usersService.Insert(user);
            var res = await _coursesService.Delete(Id);
            return Ok(res);
        }
        [HttpPost("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id) 
        {
            Users user = new Users()
            {
                IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                WhatRequest = "GetByCategory",
                Browser = HttpContext.WebSockets.ToString(),
                VisitTime = DateTime.Now
            };
            await _usersService.Insert(user);
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
            Users user = new Users()
            {
                IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                WhatRequest = "GetByAuthor",
                Browser = HttpContext.WebSockets.ToString(),
                VisitTime = DateTime.Now
            };
            await _usersService.Insert(user);
            var geta = await _coursesService.GetByAuthor(id);
            if (geta == null)
            {
                return Ok("Author Is not Found");
            }
            return Ok(geta);
        }

    }
    
}
