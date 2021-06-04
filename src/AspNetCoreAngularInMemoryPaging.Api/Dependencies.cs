using AspNetCoreAngularInMemoryPaging.Api.Data;
using AspNetCoreAngularInMemoryPaging.Api.Extensions;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace AspNetCoreAngularInMemoryPaging.Api
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "",
                    Description = "",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = ""
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });

                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(isOriginAllowed: _ => true)
                .AllowCredentials()));

            services.AddValidation(typeof(Startup));

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(IAspNetCoreAngularInMemoryPagingDbContext));

            services.AddTransient<IAspNetCoreAngularInMemoryPagingDbContext, AspNetCoreAngularInMemoryPagingDbContext>();

            services.AddDbContext<AspNetCoreAngularInMemoryPagingDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameof(AspNetCoreAngularInMemoryPaging.Api))
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();
            });

            services.AddControllers();
        }
    }
}
