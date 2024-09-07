namespace Planning.Domain.Dtos.RoutineDtos
{
    public class CreateRoutineDto
    {
        public string Name { get; set; } = "";
        public DateOnly LastDone { get; set; }
        public int FrequencyInDays { get; set; }
    }
}
