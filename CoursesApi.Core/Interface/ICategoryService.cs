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
        Task<List<Category>> GetAll();
        Task<Category> Get(int id);
        Task<string> Update(Category course);
        Task<string> Delete(int id);
        Task<string> Insert(Category model);
    }
}
