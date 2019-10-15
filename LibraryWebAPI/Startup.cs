using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebAPI.Store;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using LibraryWebAPI.Store.Repositories;
using LibraryWebAPI.Store.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LibraryWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddTransient<IBookRepository, BookRepository>()
                .AddTransient<IBookService, BookService>();

            services.AddTransient<IStudentRepository, StudentRepository>()
                .AddTransient<IStudentService, StudentService>();

            services.AddTransient<IBookIssueRepository, BookIssueRepository>()
                .AddTransient<IBookIssueService, BookIssueService>();

            services.AddTransient<IReturnBookRepository, ReturnBookRepository>()
                .AddTransient<IReturnBookService, ReturnBookService>();

            services.AddTransient<IReportingService, ReportingService>();

            

            services.AddTransient<IUnitOfWorkLibraryService, UnitOfWorkLibraryService>();



           services.AddTransient<UnitOfWorkLibraryService>(x => new UnitOfWorkLibraryService(connectionString, migrationAssemblyName))
                .AddTransient<LibraryContext>(x => new LibraryContext(connectionString, migrationAssemblyName));

            services.AddDbContext<LibraryContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<LibraryContext>(x => x.UseSqlServer(connectionString, m =>m.MigrationsAssembly(migrationAssemblyName)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
