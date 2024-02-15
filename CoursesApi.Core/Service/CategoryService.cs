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

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }
        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id);
            await _categoryRepository.Save();
        }

        public async Task<Category> Get(int id)
        {
            return (Category)await _categoryRepository.GetByID(id);
        }

        public async Task Insert(Category model)
        {
            await _categoryRepository.Insert(model);
            await _categoryRepository.Save();
        }

        public async Task<List<Category>> GetAll()
        {
            return (List<Category>)await _categoryRepository.GetAll();
        }

        public async Task Update(Category news)
        {
            await _categoryRepository.Update(news);
            await _categoryRepository.Save();
        }
    }
}
