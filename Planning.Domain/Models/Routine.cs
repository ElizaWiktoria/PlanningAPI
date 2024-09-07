using Planning.Domain.Models;

namespace Planning.Domain.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly LastDone { get; set; }
        public int FrequencyInDays { get; set; }
        public IEnumerable<Plan> Plans { get; set; } = new List<Plan>();
    }
}
