using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SampleMicroserviceSchool.Entities;

namespace SampleMicroserviceSchool.Data
{
    public class EFDataStore : IStore
    {
        private readonly AppDbContext _db;
        public EFDataStore(AppDbContext db)
        {
            _db = db;
        }

        public async Task CommitChanges()
        {
            await _db.SaveChangesAsync();
        }

        public void AddCourse(Course course)
        {
            _db.Courses.Add(course);
        }

        public void AddPayment(Payment payment)
        {
            _db.Payments.Add(payment);
        }

        public void AddStudent(Student student)
        {
            _db.Students.Add(student);
        }

        public List<Course> GetCourses()
        {
            return _db.Courses.ToList();
        }

        public List<Payment> GetPayments()
        {
            return _db.Payments.ToList();
        }

        public List<Student> GetStudents()
        {
            return _db.Students.ToList();
        }
    }
}
