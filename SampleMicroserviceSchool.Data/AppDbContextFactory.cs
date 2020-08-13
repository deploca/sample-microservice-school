using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SampleMicroserviceSchool.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var cn = String.Format(
                "Host={0};Database=SampleMicroserviceSchool;Username={1};Password={2}",
                "localhost", "postgres", "123456");

            var optionsBuilderObject = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilderObject.UseNpgsql(cn);

            return new AppDbContext(optionsBuilderObject.Options);
        }
    }
}
