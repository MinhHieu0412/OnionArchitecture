using ServiceLayer.Service;

using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using ServiceLayer.Dto;

namespace Day8.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICustomService<StudentDto> service;

        public StudentController(ICustomService<StudentDto> service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }
    }
}
