using CoursesApi.Core.Entities;
using CoursesApi.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface IUsersService
    {
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task Insert(Users ipAddress);
        Task<ServiceResponse> Delete(int id);
    }
}
