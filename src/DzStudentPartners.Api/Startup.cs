using DzStudentPartners.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DzStudentPartners.Core;
using AutoMapper;
using DzStudentPartners.Domain;
using System;
using System.Collections.Generic;

namespace DzStudentPartners.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MspContext>(o => o.UseSqlServer(Configuration["Data:ConnectionString"]));
            services.AddScoped<IMspRepository, MspRepository>();
            services.AddSingleton<MspSeeder>();

            services.AddAutoMapper();

            services.AddCors();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
        IHostingEnvironment env,
        ILoggerFactory loggerFactory,
        MspSeeder seeder,
        MspContext dbContext
        )
        {
            dbContext.Database.Migrate();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            seeder.Seed();
        }
    }
}
