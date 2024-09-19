using MediatR;

namespace Dev.Challenge.Domain.Commands.Project
{
    public class ProjectCommand : IRequest<Entities.Project>
    {
        public ProjectCommand(string? name, string? description)
        {
            Name = name;
            Description = description;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
