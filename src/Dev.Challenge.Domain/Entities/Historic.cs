namespace Dev.Challenge.Domain.Entities
{
    public class Historic : Entity
    {
        public string? OldField { get; set; }
        public string? NewField { get; set; }
        public string? OperationType { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? User { get; set; }
    }
}
