using Dev.Challenge.Domain.Abstractions;

namespace Dev.Challenge.Domain.Entities
{
    public class Project : Entity, IAggregateRoot
    {
        public Project(string? name, string? description, DateTime registerDate)
        {
            Name = name;
            Description = description;
            RegisterDate = registerDate;
        }

        public string? Name { get; private set; }
        public string? Description { get; private set;}
        public DateTime RegisterDate { get; private set;}
        public bool Active { get; private set; } = true;
        public ICollection<Tasking>? Tasks { get; private set; }
    }
}