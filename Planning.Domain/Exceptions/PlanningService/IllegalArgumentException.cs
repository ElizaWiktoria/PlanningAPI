namespace Planning.Domain.Exceptions.PlanningService
{
    public class IllegalArgumentException : Exception
    {
        public IllegalArgumentException(string message) : base(message) { }
    }
}
