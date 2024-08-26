namespace PlanningAPI.Dtos.RoutineDtos
{
    public class CreateRoutineDto
    {
        public string Name { get; set; } = "";
        public string LastDone { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public int FrequencyInDays { get; set; }
    }
}
