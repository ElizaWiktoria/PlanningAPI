namespace Planning.Domain.Dtos.RoutineDtos
{
    public class MinimalRoutine
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly LastDone { get; set; }
        public int FrequencyInDays { get; set; }
    }
}
