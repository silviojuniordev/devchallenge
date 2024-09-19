using Dev.Challenge.Data.Context;
using Dev.Challenge.Data.Repository;
using Dev.Challenge.Domain.Abstractions;
using Dev.Challenge.Domain.Commands.Project;
using Dev.Challenge.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dev.Challenge.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IRequestHandler<ProjectCommand, Project>, ProjectCommandHandler>();
        }
    }
}
