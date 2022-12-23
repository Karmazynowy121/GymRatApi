namespace GymRatApi.Commands.TrainingCommands
{
    public class TrainingCreateCommand
    {
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Interval { get; set; }
        public int TrainingDuration { get; set; } = 0;
        public int TrainingScheudleId { get; set; }
    }
}
