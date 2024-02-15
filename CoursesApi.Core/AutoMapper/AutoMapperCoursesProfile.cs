using AutoMapper;
using CoursesApi.Core.Entities;
using CoursesApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.AutoMapper
{
    public class AutoMapperCoursesProfile : Profile
    {
        public AutoMapperCoursesProfile()
        {
            CreateMap<CoursesDto, Courses>().ReverseMap();

        }
    }
}
