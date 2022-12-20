namespace GymRatApi.Commands.TrainingPartCommands
{
    public class TrainingPartCreateCommand
    {
        public int ExerciseId { get; set; }
        public int TrainingId { get; set; }
        public int AmountSeries { get; set; }
        public int BodyWeight { get; set; }
        public int BreakBetweenSeries { get; set; }
        public int Reps { get; set; }
    }
}
