using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SampleMicroserviceSchool.Students.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .MigrateDatabase()
                .Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

    public static class ProgramHelpers
    {
        public static IWebHost MigrateDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<Data.AppDbContext>())
                {
                    try
                    {
                        var isFirstRun = dbContext.Database.CanConnect() == false;
                        dbContext.Database.Migrate();

                        if (isFirstRun)
                        {
                            // add sample data
                            var sampleData = new Data.SampleDataStore();
                            dbContext.Students.AddRange(sampleData.GetStudents());
                            dbContext.Courses.AddRange(sampleData.GetCourses());
                            dbContext.Payments.AddRange(sampleData.GetPayments());
                            dbContext.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
