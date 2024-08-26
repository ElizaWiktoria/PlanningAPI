namespace PlanningAPI.Dtos.PlanDtos
{
    public class CreatePlanDto
    {
        public required string Name { get; set; }
        public DateTime Start { get; set; }
        public int? RoutineId { get; set; }
    }
}
