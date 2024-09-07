using Planning.Domain.Dtos.PlanDtos;

namespace Planning.Domain.Dtos.RoutineDtos
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
