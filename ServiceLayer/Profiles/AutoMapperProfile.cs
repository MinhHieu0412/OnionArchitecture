using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Profiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
