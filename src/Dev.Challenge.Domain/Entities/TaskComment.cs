namespace Dev.Challenge.Domain.Entities
{
    public class TaskComment : Entity
    {
        public Guid TaskingId { get; set; }
        public Tasking? Tasking { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }
    }
}