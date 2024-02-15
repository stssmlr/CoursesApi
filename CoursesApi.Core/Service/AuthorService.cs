using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;

        }
        public async Task Delete(int id)
        {
            await _authorRepository.Delete(id);
            await _authorRepository.Save();
        }

        public async Task<Author> Get(int id)
        {
            return (Author)await _authorRepository.GetByID(id);
        }

        public async Task Insert(Author model)
        {
            await _authorRepository.Insert(model);
            await _authorRepository.Save();
        }

        public async Task<List<Author>> GetAll()
        {
            return (List<Author>)await _authorRepository.GetAll();
        }

        public async Task Update(Author news)
        {
            await _authorRepository.Update(news);
            await _authorRepository.Save();
        }
    }
}
