
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface ICoursesService
    {
        Task<string> Insert(InsertCoursesDto model);
        Task<List<CoursesDto>> GetAll();
        Task<CoursesDto> Get(int id);
        Task<string> Update(InsertCoursesDto course);
        Task<string> Delete(int id);
        Task<List<CoursesDto>> GetByCategory(int id);
        Task<List<CoursesDto>> GetByAuthor(int id);

    }
}
