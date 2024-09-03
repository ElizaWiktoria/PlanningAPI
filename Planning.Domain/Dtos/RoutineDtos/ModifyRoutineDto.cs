namespace PlanningAPI.Dtos.RoutineDtos
{
    public class ModifyRoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastDone { get; set; }
        public int FrequencyInDays { get; set; }
    }
}
