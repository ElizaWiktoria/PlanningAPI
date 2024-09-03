
using PlanningAPI.Dtos.RoutineDtos;

namespace PlanningAPI.Dtos.PlanDtos
{
    public class PlanDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Start { get; set; }
        public MinimalRoutine? Routine { get; set; }
    }
}
