using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.CountryRegistryService;
using BoxTI.Challenge.CovidTracking.Services.CSVService;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BoxTI.Challenge.CovidTracking.API
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
            services.AddControllers();
            services.AddDbContext<MySqlContext>();
            services.AddHttpClient();
            services.AddTransient<ICovidService, CovidService>();
            services.AddTransient<IBaseService<CountryRegistry>, BaseService<CountryRegistry>>();
            services.AddTransient<ICountryRegistryService, CountryRegistryService>();
            services.AddTransient<ICsvService, CsvService>();
            services.AddTransient<ICountryRegistryRepository, CountryRegistryRepository>();
            services.AddTransient<IBaseRepository<CountryRegistry>, BaseRepository<CountryRegistry>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BoxTI Challenge - CovidTracking",
                    Version = "v1",
                    Description = "WebAPI da aplicação do desafio da BoxTI de CovidTracking",
                    Contact = new OpenApiContact
                    {
                        Name = "Jhonata Amado Galante",
                        Email = "jhonata.galante@gmail.com",
                        Url = new Uri("https://github.com/JhonGalante")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CovidRegistry v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
