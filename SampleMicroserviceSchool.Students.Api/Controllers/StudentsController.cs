using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleMicroserviceSchool.Students.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly Data.IStore _store;
        public StudentsController(Data.IStore store)
        {
            _store = store;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dtos.StudentDto>>> Get()
        {
            var students = _store.GetStudents();
            var courses = _store.GetCourses();
            return students.Select(x => new Dtos.StudentDto
            {
                StudentId = x.Id,
                StudentName = x.Name,
                CourseId = x.CourseId,
                CourseName = x.CourseId.HasValue ? courses.Single(y => y.Id == x.CourseId).Name : "",
            }).ToList();
        }
    }
}
