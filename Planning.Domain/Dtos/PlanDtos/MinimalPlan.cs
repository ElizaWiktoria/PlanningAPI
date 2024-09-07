namespace Planning.Domain.Dtos.PlanDtos
{
    public class MinimalPlan
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Start { get; set; }
    }
}
