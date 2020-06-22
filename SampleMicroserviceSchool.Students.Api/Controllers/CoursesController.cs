using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleMicroserviceSchool.Students.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly Data.IStore _store;
        public CoursesController(Data.IStore store)
        {
            _store = store;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entities.Course>> Get()
        {
            return _store.GetCourses();
        }
    }
}
