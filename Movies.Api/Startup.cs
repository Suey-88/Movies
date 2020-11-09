 using System;
using System.Linq;
using Movies.EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.BusinessLogic.ServicesInterface;
using Movies.BusinessLogic.Services;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Movies.Api.Models.Helpers;

namespace Movie.Api
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
            services.AddDbContext<MoviesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));

            });

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movies API",
                    Description = "A movies API Project",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Sue",
                        Email = "sue@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddScoped<IMoviesService, MoviesService>();
            
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseCors(x => x.AllowAnyOrigin());
            app.UseRouting();
            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies Docs");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
