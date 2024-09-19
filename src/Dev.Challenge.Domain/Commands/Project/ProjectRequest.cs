using System.ComponentModel.DataAnnotations;

namespace Dev.Challenge.Domain.Commands.Project
{
    public class ProjectRequest
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
