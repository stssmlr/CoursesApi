
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface ICoursesService
    {
        Task<ServiceResponse> Insert(InsertCoursesDto model);
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Update(InsertCoursesDto course);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> GetByCategory(int id);
        Task<ServiceResponse> GetByAuthor(int id);

    }
}
