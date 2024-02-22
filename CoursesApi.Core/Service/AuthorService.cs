using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Entities.Specifications;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ServiceResponse> Delete(int id)
        {
            List<Courses> courses = (List<Courses>)await _coursesRepository.GetAll();
            foreach (Courses c in courses)
            {
                if (c.AuthorId == id)
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Delete The Course Of This Author",
                        Payload = null
                    };
                }
            }
            List<Author> Authors = (List<Author>)await _authorRepository.GetAll();
            foreach (Author a in Authors)
            {
                if (a.Id == id)
                {
                    await _authorRepository.Delete(id);
                    await _authorRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Deleted",
                        Payload = null
                    };
                }
            }
            return new ServiceResponse
            {
                Success = false,
                Message = "This Author Doesn't Exist",
                Payload = null
            };
        }
        public async Task<ServiceResponse> GetByEmail(string email)
        {
            var data = await _authorRepository.GetItemBySpec(new AuthorSpecification.ByEmail(email));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Author Was Successfully Found",
                    Payload = data
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Something went wrong",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> Get(int id)
        {
            var data = (Author)await _authorRepository.GetByID(id);
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Author Was Successfully Loaded",
                    Payload = data
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Something went wrong",
                    Payload = null
                };
            }
        }


        public async Task<ServiceResponse> Insert(Author model)
        {
            List<Author> authors = (List<Author>)await _authorRepository.GetAll();
            foreach (Author category in authors)
            {
                if (category.Equals(model))
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Author Is Already In Database",
                        Payload = null
                    };
                }
            }
            await _authorRepository.Insert(model);
            await _authorRepository.Save();
            return new ServiceResponse
            {
                Success = true,
                Message = "AuthorWas Successfully Created",
                Payload = null
            };
        }

        public async Task<ServiceResponse> GetAll()
        {
            var data = (List<Author>)await _authorRepository.GetAll();
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All Authors Successfully Loaded",
                    Payload = data
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Something went wrong",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> Update(Author course)
        {
            List<Author> authors = (List<Author>)await _authorRepository.GetAll();
            foreach (Author a in authors)
            {
                if (a.Id == course.Id)
                {
                    await _authorRepository.Update(course);
                    await _authorRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Author Updated",
                        Payload = null
                    };
                }
            }
            return new ServiceResponse
                {
                    Success = false,
                    Message = "Something went wrong",
                    Payload = null
                };
        }
    }
}
