using CoursesApi.Core.Entities;
using CoursesApi.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface ICategoryService
    {
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Update(Category course);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Insert(Category model);
    }
}
