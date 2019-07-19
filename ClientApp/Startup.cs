using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using AutoMapper;
using System;
using Application.Security.Repositories;
using Application.Security.Hashing;
using Application.Security.Tokens;
using Application.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using ClientApp.Validation;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using Application.Configs;
using ClientApp.VerificationPlatform;
using ClientApp.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
//using Serilog;

namespace ClientApp
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MoisContext>(c => c.UseSqlServer(Configuration.GetConnectionString("MoisConnection")));

            services.AddScoped<IUnitOfWork, MoisContext>();
            services.AddScoped<IRepository<LookupBase>, EfRepository<LookupBase>>();
            //services.AddScoped<IRepository<Request>, EfRepository<Request>>();
            services.AddScoped<ICachedLookupsService, CachedLookupsService>();
            services.AddScoped<ILookupsService, LookupsService>();
            //services.AddScoped<ILookupsRepository<Gender>, LookupsRepository<Gender>>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<ICsrService, CsrService>();
            services.AddScoped<ICsrRepository, CsrRepository>();
            services.AddScoped<IBirthDocService, BirthDocService>();
            services.AddScoped<IBirthDocRepository, BirthDocRepository>();
            services.AddScoped<IDeathDocService, DeathDocService>();
            services.AddScoped<IDeathDocRepository, DeathDocRepository>();
            services.AddScoped<IMarriageDocService, MarriageDocService>();
            services.AddScoped<IMarriageDocRepository, MarriageDocRepository>();
            services.AddScoped<IDivorceDocService, DivorceDocService>();
            services.AddScoped<IDivorceDocRepository, DivorceDocRepository>();
            services.AddScoped<INidDocService, NidDocService>();
            services.AddScoped<INidDocRepository, NidDocRepository>();

            services.AddScoped<ITokenVerificationService, TokenVerificationService>();

            ConfigureSecurityServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MOI requests services Api Docs", Version = "v1", Description= "Create requests for MOI services." });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>>{{ "Bearer", new string[] { } }
                });
            });

            services.AddMemoryCache();
            //We used the AddJsonOptions because without it, all json prop sent to the client will be in camelCase, so adding this will prevent this odd behavior
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddFluentValidation(fv =>
                {
                    //This will automatically find any public, non-abstract types that inherit from AbstractValidator
                    //and register them with the container (open generics are not supported so we use type to just bypass this).
                    fv.RegisterValidatorsFromAssemblyContaining<RequestResourceInValidator>();
                    //By using this: MVC’s validation infrastructure will recursively attempt to automatically find validators for each property
                    fv.ImplicitlyValidateChildProperties = true;
                });

            // override modelstate
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    _logger.LogError("Validation errors occurred: {@validationErrors}", errors);
                    return new BadRequestObjectResult(context.ModelState);
                };
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddHealthChecks().AddCheck<ApiHealthCheck>("health-check");
        }

        private void ConfigureSecurityServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, Application.Security.Tokens.TokenHandler>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            //services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            //var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.Configure<AppConfigs>(Configuration.GetSection("AppConfigs"));
            var tokenOptions = Configuration.GetSection("AppConfigs").GetSection("TokenOptions").Get<TokenOptions>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            ConfigureAuth(services, tokenOptions, signingConfigurations);
        }

        protected virtual void ConfigureAuth(IServiceCollection services, TokenOptions tokenOptions, SigningConfigurations signingConfigurations)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.Key,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, ILoggerFactory loggerFactory*/)
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MOI requests services Api");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            //For token validations to correctly work, 
            //it is necessary to use UseAuthentication middleware before the middleware that configures routes for the application.
            app.UseAuthentication();
            //// logging
            //loggerFactory.AddSerilog();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseHealthChecks("/health-check",
            new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonConvert.SerializeObject(
                        new
                        {
                            status = report.Status.ToString(),
                            results = report.Entries.Select(e => new
                            {
                                key = e.Key,
                                value = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                                description= e.Value.Description
                            })
                        });
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
