using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleMicroserviceSchool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Entities.Student> Students { get; set; }
        public virtual DbSet<Entities.Course> Courses { get; set; }
        public virtual DbSet<Entities.Payment> Payments { get; set; }
    }
}
