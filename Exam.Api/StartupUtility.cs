using Exam.BusinessRule;
using Exam.Common.Configuration;
using Exam.Common.Contract.BusinessRule;
using Exam.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Versioning;
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
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Exam API",
                    Description = "An ASP.NET Core Web API for Interview Exam items"
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

        public static void RegisterScopedServices(this IServiceCollection service)
        {
            service.AddScoped<IStudentBusinessRule, StudentBusinessRule>();
            service.AddScoped<IUniversityBusinessRule, UniversityBusinessRule>();
        }

        public static void RegisterSingletonServices(this IServiceCollection service)
        {
            service.AddSingleton<IStudentBusinessRule, StudentBusinessRule>();
            service.AddSingleton<IUniversityBusinessRule, UniversityBusinessRule>();
        }

        public static void RegisterTransientServices(this IServiceCollection service)
        {
            service.AddTransient<IStudentBusinessRule, StudentBusinessRule>();
            service.AddTransient<IUniversityBusinessRule, UniversityBusinessRule>();
        }

        public static void RegisterServices(this IServiceCollection services,RegisterServiceType registerType = RegisterServiceType.Scoped)
        {
            switch (registerType)
            {
                case RegisterServiceType.Singleton:
                    RegisterSingletonServices(services);
                    break;
                case RegisterServiceType.Transient:
                    RegisterTransientServices(services);
                    break;
                case RegisterServiceType.Scoped:
                    RegisterScopedServices(services);
                    break;
            }
        }
    }
}
