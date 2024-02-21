
using AutoMapper;
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
    public class CoursesService : ICoursesService
    {
        private readonly IRepository<Courses> _coursesRepository;
        private readonly IMapper _mapper;

        public CoursesService(IRepository<Courses> coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }
        public async Task<string> Delete(int id)
        {
            
            List<Courses> Courses = (List<Courses>)await _coursesRepository.GetAll();
            foreach (Courses a in Courses)
            {
                if (a.Id == id)
                {
                    await _coursesRepository.Delete(id);
                    await _coursesRepository.Save();
                    return "Delete";
                }
            }
            return "Courses does not exist";
        }

        public async Task<CoursesDto> Get(int id)
        {
            return _mapper.Map<CoursesDto>(await _coursesRepository.GetByID(id));
        }

        public async Task<List<CoursesDto>> GetAll()
        {
            return _mapper.Map<List<CoursesDto>>(await _coursesRepository.GetAll());
        }

        public async Task<string> Update(InsertCoursesDto course)
        {
            List<InsertCoursesDto> categorys = _mapper.Map<List<InsertCoursesDto>>(await _coursesRepository.GetAll());
            foreach (InsertCoursesDto a in categorys)
            {
                if (a.Id == course.Id)
                {
                    await _coursesRepository.Update(_mapper.Map<Courses>(course));
                    await _coursesRepository.Save();
                    return "Update";
                }
            }
            return "Such a course does not exist";
        }

        public async Task<List<CoursesDto>> GetByCategory(int id)
        {
            var result = await _coursesRepository.GetListBySpec(new CoursesSpecification.ByCategory(id));
            return _mapper.Map<List<CoursesDto>>(result);
        }
        
        public async Task<List<CoursesDto>> GetByAuthor(int id)
        {
            var result = await _coursesRepository.GetListBySpec(new CoursesSpecification.ByAuthor(id));
            return _mapper.Map<List<CoursesDto>>(result);
        }
        public async Task<string> Insert(InsertCoursesDto course)
        {
            List<InsertCoursesDto> courses = _mapper.Map<List<InsertCoursesDto>>(await _coursesRepository.GetAll());
            foreach (InsertCoursesDto category in courses)
            {
                if (category.Equals(course))
                {
                    return "Course Is Already In Database";
                }
            }
            await _coursesRepository.Insert(_mapper.Map<Courses>(course));
            await _coursesRepository.Save();
            return "Course successfully added!";
        }

    }
}
