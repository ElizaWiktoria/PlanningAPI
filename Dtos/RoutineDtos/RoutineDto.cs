using PlanningAPI.Dtos.PlanDtos;

namespace PlanningAPI.Dtos.RoutineDtos
{
    public class RoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly LastDone { get; set; }
        public int FrequencyInDays { get; set; }
        public IEnumerable<MinimalPlan> Plans { get; set; } = new List<MinimalPlan>();
    }
}
