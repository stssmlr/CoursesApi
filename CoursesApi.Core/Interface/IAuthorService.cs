using CoursesApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interface
{
    public interface IAuthorService
    {
        Task<string> Insert(Author model);
        Task<List<Author>> GetAll();
        Task<Author> Get(int id);
        Task<string> Update(Author course);
        Task<string> Delete(int id);
        Task<Author> GetByEmail(string email);
    }
}
