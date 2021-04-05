using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.BusinessLayer.Services;
using DIMS_Core.DataAccessLayer.Extensions;
using DIMS_Core.Identity.Extensions;
using DIMS_Core.Mailer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DIMS_Core.BusinessLayer.Extensions
{
    public static class MiddlewareServiceExtensions
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IDirectionService, DirectionService>();

            services.AddScoped<ITaskStateService, TaskStateService>();
            services.AddScoped<IService<TaskTrackModel>, TaskTrackService>();
            services.AddScoped<IService<UserTaskModel>, UserTaskService>();

            services.AddScoped<IVUserProfileService, VUserProfileService>();
            services.AddScoped<IReadOnlyService<VUserProgressModel>, VUserProgressService>();
            services.AddScoped<IReadOnlyService<VUserTaskModel>, VUserTaskService>();

            services.AddDatabaseDependencies()
                    .AddIdentityDependencies()
                    .AddMailerDependencies();

            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services, params Assembly[] otherMapperAssemblies)
        {
            var assemblies = new List<Assembly>(otherMapperAssemblies)
                             {
                                 Assembly.GetExecutingAssembly()
                             };
            
            services.AddAutoMapper(assemblies);

            return services;
        }

        public static IServiceCollection AddCustomSolutionConfigs(this IServiceCollection services,
                                                                  IConfiguration configuration,
                                                                  params Assembly[] otherMapperAssemblies)
        {
            services.AddDependencyInjections()
                    .AddDatabaseContext(configuration)
                    .AddAutomapperProfiles(otherMapperAssemblies)
                    .AddIdentityContext();

            return services;
        }
    }
}