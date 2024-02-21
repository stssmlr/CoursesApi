using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Entities.Specifications;
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
        private readonly IRepository<Courses> _coursesRepository;

        public AuthorService(IRepository<Author> authorRepository, IRepository<Courses> coursesRepository)
        {
            _authorRepository = authorRepository;
            _coursesRepository = coursesRepository;
        }
        public async Task<string> Delete(int id)
        {
            List<Courses> courses = (List<Courses>)await _coursesRepository.GetAll();
            foreach (Courses c in courses)
            {
                if (c.AuthorId == id)
                {
                    return "Delete the course of this author";
                }
            }
            List<Author> Authors = (List<Author>)await _authorRepository.GetAll();
            foreach (Author a in Authors)
            {
                if (a.Id == id)
                {
                    await _authorRepository.Delete(id);
                    await _authorRepository.Save();
                    return "Delete";
                }
            }
            return "Author does not exist";
        }
        public async Task<Author> GetByEmail(string email)
        {
            var result = await _authorRepository.GetItemBySpec(new AuthorSpecification.ByEmail(email));
            return (result);
        }

        public async Task<Author> Get(int id)
        {
            return (Author)await _authorRepository.GetByID(id);
        }


        public async Task<string> Insert(Author model)
        {
            List<Author> authors = (List<Author>)await _authorRepository.GetAll();
            foreach (Author category in authors)
            {
                if (category.Equals(model))
                {
                    return "Course Is Already In Database";
                }
            }
            await _authorRepository.Insert(model);
            await _authorRepository.Save();
            return "Course successfully added!";
        }

        public async Task<List<Author>> GetAll()
        {
            return (List<Author>)await _authorRepository.GetAll();
        }

        public async Task<string> Update(Author course)
        {
            List<Author> authors = (List<Author>)await _authorRepository.GetAll();
            foreach (Author a in authors)
            {
                if (a.Id == course.Id)
                {
                    await _authorRepository.Update(course);
                    await _authorRepository.Save();
                    return "Update";
                }
            }
            return "Such a author does not exist";
        }
    }
}
