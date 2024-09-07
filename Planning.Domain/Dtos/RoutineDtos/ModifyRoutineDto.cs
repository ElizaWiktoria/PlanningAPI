namespace Planning.Domain.Dtos.RoutineDtos
{
    public class ModifyRoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastDone { get; set; } = string.Empty;
        public int FrequencyInDays { get; set; }
    }
}
