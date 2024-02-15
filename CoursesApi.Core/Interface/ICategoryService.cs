using CoursesApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface ICategoryService
    {
        Task Insert(Category model);
        Task<List<Category>> GetAll();
        Task<Category> Get(int id);
        Task Update(Category role);
        Task Delete(int id);
    }
}
