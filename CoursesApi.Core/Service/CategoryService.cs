using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<string> Delete(int id)
        {
            List<Courses> courses = (List<Courses>)await _coursesRepository.GetAll();
            foreach (Courses c in courses)
            {
                if (c.CategoryId == id)
                {
                    return "Delete the course of this category";
                }
            }
            List<Category> Authors = (List<Category>)await _categoryRepository.GetAll();
            foreach (Category a in Authors)
            {
                if (a.Id == id)
                {
                    await _categoryRepository.Delete(id);
                    await _categoryRepository.Save();
                    return "Delete";
                }
            }
            return "Category does not exist";
        }

        public async Task<Category> Get(int id)
        {
            return (Category)await _categoryRepository.GetByID(id);
        }

        public async Task<string> Insert(Category model)
        {
            List<Category> categories = (List<Category>)await _categoryRepository.GetAll();
            foreach (Category category in categories)
            {
                if (category.Equals(model))
                {
                    return "Category Is Already In Database";
                }
            }
            await _categoryRepository.Insert(model);
            await _categoryRepository.Save();
            return "Category successfully added!";
        }

        public async Task<List<Category>> GetAll()
        {
            return (List<Category>)await _categoryRepository.GetAll();
        }

        public async Task<string> Update(Category course)
        {
            List<Category> categories = (List<Category>)await _categoryRepository.GetAll();
            foreach (Category a in categories)
            {
                if (a.Id == course.Id)
                {
                    await _categoryRepository.Update(course);
                    await _categoryRepository.Save();
                    return "Update";
                }
            }
            return "Category does not exist";
        }
    }
}
