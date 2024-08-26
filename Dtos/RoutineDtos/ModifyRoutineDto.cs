namespace PlanningAPI.Dtos.RoutineDtos
{
    public class ModifyRoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastDone { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public int FrequencyInDays { get; set; }
    }
}
