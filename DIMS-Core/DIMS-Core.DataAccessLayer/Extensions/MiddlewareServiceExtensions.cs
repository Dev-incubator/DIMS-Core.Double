using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DIMS_Core.DataAccessLayer.Extensions
{
    public static class MiddlewareServiceExtensions
    {
        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Direction>, DirectionRepository>();
            services.AddScoped<IRepository<UserProfile>, UserProfileRepository>();
            services.AddScoped<IRepository<Task>, TaskRepository>();
            services.AddScoped<IRepository<UserTask>, UserTaskRepository>();
            services.AddScoped<IRepository<TaskTrack>, TaskTrackRepository>();
            services.AddScoped<ITaskStateRepository, TaskStateRepository>();
            services.AddScoped<IReadOnlyRepository<VUserProfile>, VUserProfileRepository>();
            services.AddScoped<IReadOnlyRepository<VTask>, VTaskRepository>();
            services.AddScoped<IReadOnlyRepository<VUserProgress>, VUserProgressRepository>();
            services.AddScoped<IReadOnlyRepository<VUserTask>, VUserTaskRepository>();
            services.AddScoped<IReadOnlyRepository<VUserTrack>, VUserTrackRepository>();

            return services;
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DIMSCoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DIMSDatabase"));
            });

            return services;
        }
    }
}