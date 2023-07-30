using Microsoft.AspNetCore.Mvc;
using StudentApı.DomainModels;
using StudentApı.Repositories;

namespace StudentApı.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllStudents()
        {
            var students = studentRepository.GetStudents();

            var domainStudent = new List<Student>();

            foreach (var student in students)
            {
                domainStudent.Add(new Student()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    lastName = student.lastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderId = student.GenderId,
                });
                
            }

            return Ok(domainStudent); 
        }
    }
}
