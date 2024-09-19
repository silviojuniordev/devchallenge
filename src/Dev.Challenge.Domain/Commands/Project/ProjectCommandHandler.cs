using Dev.Challenge.Domain.Abstractions;
using Dev.Challenge.Domain.DTO.Project;
using MediatR;

namespace Dev.Challenge.Domain.Commands.Project
{
    public class ProjectCommandHandler : IRequestHandler<ProjectCommand, Entities.Project>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Entities.Project> Handle(ProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Entities.Project(request?.Name, request?.Description, request.RegisterDate);
            _projectRepository.Add(project);

            return Task.FromResult(project);
        }
    }
}
