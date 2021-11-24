using AutoMapper;
using BoxTI.Challenge.CovidTracking.API.Auth;
using BoxTI.Challenge.CovidTracking.API.Models.Models;
using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Data.Dapper;
using BoxTI.Challenge.CovidTracking.Data.Repository;
using BoxTI.Challenge.CovidTracking.Data.Repository.UserRepository;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.CountryRegistryService;
using BoxTI.Challenge.CovidTracking.Services.CSVService;
using BoxTI.Challenge.CovidTracking.Services.HashService;
using BoxTI.Challenge.CovidTracking.Services.Services;
using BoxTI.Challenge.CovidTracking.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

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

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<User, LoginResult>().ReverseMap();
                mc.CreateMap<CountryRegistry, CountryRegistryResult>().ReverseMap();
            });

            var mapper = mappingConfig.CreateMapper();

            services.AddTransient<IBaseService<CountryRegistry>, BaseService<CountryRegistry>>();
            services.AddTransient<ICovidService, CovidService>();
            services.AddTransient<ICountryRegistryService, CountryRegistryService>();
            services.AddTransient<ICsvService, CsvService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHashService, HashService>();

            services.AddTransient<IBaseRepository<CountryRegistry>, BaseRepository<CountryRegistry>>();
            services.AddTransient<ICountryRegistryRepository, CountryRegistryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddScoped<DbSession>();
            services.AddSingleton(mapper);
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BoxTI Challenge - CovidTracking",
                    Version = "v1",
                    Description = "WebAPI from BoxTI Challenge of CovidTracking",
                    Contact = new OpenApiContact
                    {
                        Name = "Jhonata Amado Galante",
                        Email = "jhonata.galante@gmail.com",
                        Url = new Uri("https://github.com/JhonGalante")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme." +
                    "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                    "\r\n\r\n Example: \"Bearer 12345abcdef\""
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
