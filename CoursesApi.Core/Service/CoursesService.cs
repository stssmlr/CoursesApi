
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
        public async Task Delete(int id)
        {
            await _coursesRepository.Delete(id);
            await _coursesRepository.Save();
        }

        public async Task<CoursesDto> Get(int id)
        {
            return _mapper.Map<CoursesDto>(await _coursesRepository.GetByID(id));
        }

        public async Task Insert(InsertCoursesDto model)
        {
            await _coursesRepository.Insert(_mapper.Map<Courses>(model));
            await _coursesRepository.Save();
        }

        public async Task<List<CoursesDto>> GetAll()
        {
            return _mapper.Map<List<CoursesDto>>(await _coursesRepository.GetAll());
        }

        public async Task Update(InsertCoursesDto news)
        {
            await _coursesRepository.Update(_mapper.Map<Courses>(news));
            await _coursesRepository.Save();
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
        
    }
}
