using System;
using System.Collections.Generic;

namespace SampleMicroserviceSchool.Entities
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
