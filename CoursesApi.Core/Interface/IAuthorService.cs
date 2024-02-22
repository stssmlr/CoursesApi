using CoursesApi.Core.Entities;
using CoursesApi.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface IAuthorService
    {
        Task<ServiceResponse> Insert(Author model);
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Update(Author course);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> GetByEmail(string email);
    }
}
