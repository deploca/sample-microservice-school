using System;
using System.Collections.Generic;
using SampleMicroserviceSchool.Entities;

namespace SampleMicroserviceSchool.Data
{
    public interface IStore
    {
        List<Course> GetCourses();
        List<Student> GetStudents();
        List<Payment> GetPayments();

        void AddCourse(Course course);
        void AddStudent(Student student);
        void AddPayment(Payment payment);
    }
}
