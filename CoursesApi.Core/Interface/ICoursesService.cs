
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
        Task Insert(Courses model);
        Task<List<Courses>> GetAll();
        Task<Courses> Get(int id);
        Task Update(Courses news);
        Task Delete(int id);
        Task<List<Courses>> GetByCategory(int id);
    }
}
