using CarAPI.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.API.Installers
{
    public class APIInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();

            services.AddDbContext<CarContext>(options => options.UseSqlite(configuration.GetConnectionString("CarDBConneciton")));

            //Enable CORS
            services.AddCors(option =>
            {
                option.AddPolicy(
                    "CARApiPolicy",
                    builder =>
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());
            });

            // Add default Filters to all Controller more generic way
            services.AddControllers(options =>
            {
                //options.Filters.Add(new ApiExceptionFilterAttribute());
                //options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), 500));

            })//.AddFluentValidation(fv => fv.ImplicitlyValidateChildProperties = true)
            .AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.IgnoreNullValues = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // access HTTPContext Accessor
            services.AddHttpContextAccessor();
        }
    }
}
