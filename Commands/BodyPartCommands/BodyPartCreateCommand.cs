namespace GymRatApi.Commands.BodyPartCommands
{
    public class BodyPartCreateCommand
    {
        public string Name { get; set; }
        public int HowManyExercisePerWeek { get; set; }
        public int ExerciseId { get; set; }
    }
}
