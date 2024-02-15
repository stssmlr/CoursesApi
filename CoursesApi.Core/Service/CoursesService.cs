
using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Service
{
    public class CoursesService : ICoursesService
    {
        private readonly IRepository<Courses> _coursesRepository;

        public CoursesService(IRepository<Courses> newsRepository)
        {
            _coursesRepository = newsRepository;

        }
        public async Task Delete(int id)
        {
            await _coursesRepository.Delete(id);
            await _coursesRepository.Save();
        }

        public async Task<Courses> Get(int id)
        {
            return (Courses)await _coursesRepository.GetByID(id);
        }

        public async Task Insert(Courses model)
        {
            await _coursesRepository.Insert(model);
            await _coursesRepository.Save();
        }

        public async Task<List<Courses>> GetAll()
        {
            return (List<Courses>)await _coursesRepository.GetAll();
        }

        public async Task Update(Courses news)
        {
            await _coursesRepository.Update(news);
            await _coursesRepository.Save();
        }
    }
}
