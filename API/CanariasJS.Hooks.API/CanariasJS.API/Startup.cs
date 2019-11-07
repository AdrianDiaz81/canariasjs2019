using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanariasJS.API.Infraestucture.Middleware;
using CanariasJS.Hooks.API.Data;
using CanariasJS.Hooks.API.Domain;
using CanariasJS.Hooks.API.Repository;
using CanariasJS.Hooks.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CanariasJS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Open24",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContextPool<AvengerDbContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            return services.ConfigureContainer();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IActionContextAccessor, ActionContextAccessor>();
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
            app.UseCors("Open24");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
