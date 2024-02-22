using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoursesApi.Core.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Courses> _coursesRepository;

        public CategoryService(IRepository<Category> categoryRepository, IRepository<Courses> coursesRepository)
        {
            _categoryRepository = categoryRepository;
            _coursesRepository = coursesRepository;
        }
        public async Task<ServiceResponse> Delete(int id)
        {
            List<Courses> courses = (List<Courses>)await _coursesRepository.GetAll();
            foreach (Courses c in courses)
            {
                if (c.CategoryId == id)
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Delete the course of this category",
                        Payload = null
                    };
                }
            }
            List<Category> Authors = (List<Category>)await _categoryRepository.GetAll();
            foreach (Category a in Authors)
            {
                if (a.Id == id)
                {
                    await _categoryRepository.Delete(id);
                    await _categoryRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Category Was Successfully Deleted",
                        Payload = null
                    };
                }
            }
            return new ServiceResponse
            {
                Success = false,
                Message = "Category Doesn`t Exist",
                Payload = null
            };
        }

        public async Task<ServiceResponse> Get(int id)
        {
            var data = (Category)await _categoryRepository.GetByID(id);
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All Categories Successfully Loaded",
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

        public async Task<ServiceResponse> Insert(Category model)
        {
            List<Category> categories = (List<Category>)await _categoryRepository.GetAll();
            foreach (Category category in categories)
            {
                if (category.Equals(model))
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Category Is Already In Database",
                        Payload = null
                    };
                }
            }
            await _categoryRepository.Insert(model);
            await _categoryRepository.Save();
            return new ServiceResponse
            {
                Success = true,
                Message = "All Categories Successfully Created",
                Payload = null
            };
        }

        public async Task<ServiceResponse> GetAll()
        {
            var data =  (List<Category>)await _categoryRepository.GetAll();
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All Categories Successfully Loaded",
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

        public async Task<ServiceResponse> Update(Category course)
        {
            List<Category> categories = (List<Category>)await _categoryRepository.GetAll();
            foreach (Category a in categories)
            {
                if (a.Id == course.Id)
                {
                    await _categoryRepository.Update(course);
                    await _categoryRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "All Categories Successfully Updated",
                        Payload = null
                    };
                }
            }
            return new ServiceResponse
            {
                Success = false,
                Message = "Category doesn't exist",
                Payload = null
            };
        }
    }
}
