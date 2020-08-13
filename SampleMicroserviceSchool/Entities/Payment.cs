using System;
using System.Collections.Generic;

namespace SampleMicroserviceSchool.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public decimal PayAmount { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
