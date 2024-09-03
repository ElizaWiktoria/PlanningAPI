namespace PlanningAPI.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Start { get; set; }
        public Routine? Routine { get; set; }
    }
}
