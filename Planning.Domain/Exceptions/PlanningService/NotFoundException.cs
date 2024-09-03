namespace PlanningAPI.Exceptions.PlanningService
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
