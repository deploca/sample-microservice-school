using System;
using System.Collections.Generic;

namespace SampleMicroserviceSchool.Dtos
{
    public class StudentDto
    {
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public long? CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
