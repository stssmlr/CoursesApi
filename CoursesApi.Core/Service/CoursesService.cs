
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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ServiceResponse> Delete(int id)
        {
            
            List<Courses> Courses = (List<Courses>)await _coursesRepository.GetAll();
            foreach (Courses a in Courses)
            {
                if (a.Id == id)
                {
                    await _coursesRepository.Delete(id);
                    await _coursesRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Course Was Successfully Deleted",
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

        public async Task<ServiceResponse> Get(int id)
        {
            var data = _mapper.Map<CoursesDto>(await _coursesRepository.GetByID(id));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Course Was Successfully Loaded",
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

        public async Task<ServiceResponse> GetAll()
        {
            var data = _mapper.Map<List<CoursesDto>>(await _coursesRepository.GetAll());
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All Courses Successfully Loaded",
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

        public async Task<ServiceResponse> Update(InsertCoursesDto course)
        {
            List<InsertCoursesDto> courses = _mapper.Map<List<InsertCoursesDto>>(await _coursesRepository.GetAll());
            foreach (InsertCoursesDto a in courses)
            {
                if (a.Id == course.Id)
                {
                    await _coursesRepository.Update(_mapper.Map<Courses>(course));
                    await _coursesRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "Course Was Successfully Updated",
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

        public async Task<ServiceResponse> GetByCategory(int id)
        {
            var result = await _coursesRepository.GetListBySpec(new CoursesSpecification.ByCategory(id));
            var data = _mapper.Map<List<CoursesDto>>(result);
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Course Was Successfully Loaded",
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
        
        public async Task<ServiceResponse> GetByAuthor(int id)
        {
            var result = await _coursesRepository.GetListBySpec(new CoursesSpecification.ByAuthor(id));
            var data = _mapper.Map<List<CoursesDto>>(result);
            if (data != null)
            {
                return new ServiceResponse 
                {
                    Success = true,
                    Message = "Course Was Successfully Loaded",
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
        public async Task<ServiceResponse> Insert(InsertCoursesDto course)
        {
            List<InsertCoursesDto> courses = _mapper.Map<List<InsertCoursesDto>>(await _coursesRepository.GetAll());
            foreach (InsertCoursesDto category in courses)
            {
                if (category.Equals(course))
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Course Is Already In Database",
                        Payload = null
                    };
                }
            }
            await _coursesRepository.Insert(_mapper.Map<Courses>(course));
            await _coursesRepository.Save();
            return new ServiceResponse
            {
                Success = true,
                Message = "Course Was Successfully Created",
                Payload = null
            };
        }

    }
}
