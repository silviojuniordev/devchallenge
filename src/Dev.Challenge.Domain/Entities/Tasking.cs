using Dev.Challenge.Domain.Enum;

namespace Dev.Challenge.Domain.Entities
{
    public class Tasking : Entity
    {
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public string? Description { get; set; }
        public DateTime MaturityDate { get; set; }        
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? AssignedUser { get; set; }
        public ICollection<TaskComment>? TaskComments { get; set; }
    }
}
