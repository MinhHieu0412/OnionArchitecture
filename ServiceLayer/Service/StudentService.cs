using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.Dto;

namespace ServiceLayer.Service
{
    public class StudentService : ICustomService<StudentDto>
    {
        readonly IRepository<Student> studentRepository;
        readonly IMapper mapper;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public void Delete(StudentDto entity)
        {
            try
            {

                if (entity != null)
                {
                    Student stu = mapper.Map<Student>(entity);
                    studentRepository.Delete(stu);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<StudentDto> GetAll() {
            try
            {
                var student = studentRepository.GetAll().Select(s=>mapper.Map<StudentDto>(s));
                if (student != null)
                {
                    return student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public StudentDto Get(int id)
        {
            try
            {
                var stu = studentRepository.Get(id);
                var student = mapper.Map<StudentDto>(stu);
                if (student != null)
                {
                    return student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Insert(StudentDto entity)
        {
            try
            {
               
                if (entity != null)
                {
                    Student stu = mapper.Map<Student>(entity);
                    studentRepository.Insert(stu);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(StudentDto entity)
        {
            try
            {

                if (entity != null)
                {
                    Student stu = mapper.Map<Student>(entity);
                    studentRepository.Insert(stu);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Remove(StudentDto entity)
        {
            try
            {

                if (entity != null)
                {
                    Student stu = mapper.Map<Student>(entity);
                    studentRepository.Delete(stu);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
