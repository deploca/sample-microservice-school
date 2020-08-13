using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace SampleMicroserviceSchool.Students.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnv)
        {
            Configuration = configuration;
            HostingEnv = hostingEnv;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnv { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // database
            services.AddDbContext<Data.AppDbContext>(efOptions =>
            {
                var cn = "Host={0};Database=SampleMicroserviceSchool;Username={1};Password={2}";
                if (HostingEnv.IsDevelopment())
                    cn = string.Format(cn, "localhost", "postgres", "123456");
                else
                    cn = string.Format(cn, "database", "postgres", "");

                efOptions.UseNpgsql(cn, npgOptions =>
                    npgOptions.MigrationsAssembly(typeof(Data.AppDbContext).Assembly.GetName().Name));
            });

            // register store
            services.AddScoped<Data.IStore, Data.EFDataStore>();

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (HostingEnv.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c => c
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .Build());

            app.UseMvc();
        }
    }
}
