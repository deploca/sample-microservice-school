using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SampleMicroserviceSchool.Entities;

namespace SampleMicroserviceSchool.Data
{
    public class SampleDataStore : IStore
    {
        public List<Course> GetCourses()
        {
            return new List<Course>()
            {
                new Course { Id = 1, Name = "Acting Course" },
                new Course { Id = 2, Name = "Music Course" },
            };
        }

        public List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student { Id = 1, CourseId = 1, Name = "Johnny Depp" },
                new Student { Id = 2, CourseId = 1, Name = "Brad Pitt" },
                new Student { Id = 3, CourseId = 1, Name = "Leonardo DiCaprio" },

                new Student { Id = 4, CourseId = 2, Name = "Michael Jackson" },
                new Student { Id = 5, CourseId = 2, Name = "Freddy Mercury" },
            };
        }

        public List<Payment> GetPayments()
        {
            return new List<Payment>()
            {
                new Payment { Id = 1, StudentId = 1, CourseId = 1, PayAmount = 2000m },
                new Payment { Id = 2, StudentId = 2, CourseId = 1, PayAmount = 2000m },
                //new Payment { Id = 3, StudentId = 3, CourseId = 1, PayAmount = 2000m },

                new Payment { Id = 4, StudentId = 4, CourseId = 2, PayAmount = 3000m },
                //new Payment { Id = 5, StudentId = 5, CourseId = 2, PayAmount = 3000m },
            };
        }

        public void AddCourse(Course course)
        {
            // do nothing
        }

        public void AddStudent(Student student)
        {
            // do nothing
        }

        public void AddPayment(Payment payment)
        {
            // do nothing
        }

        public Task CommitChanges()
        {
            // do nothing
            return Task.CompletedTask;
        }
    }
}
