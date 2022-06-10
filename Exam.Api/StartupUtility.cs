using Exam.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Api
{
    public static class StartupUtility
    {
        public static void RegisterSwagger(this IServiceCollection services, ApplicationSettings settings)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Exam API",
                    Description = "An ASP.NET Core Web API for Interview Eaxm items"                    
                });
            });
        }

        public static void UseSwaggerAndUseSwaggerUI(this IApplicationBuilder app, string appName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", $"{appName} APIs Version 1.0");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
