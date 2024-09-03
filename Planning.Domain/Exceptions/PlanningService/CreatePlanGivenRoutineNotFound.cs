namespace PlanningAPI.Exceptions.PlanningService
{
    public class CreatePlanGivenRoutineNotFound : Exception
    {
        public CreatePlanGivenRoutineNotFound(string message) : base(message) { }
    }
}
