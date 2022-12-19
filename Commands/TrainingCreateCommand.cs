namespace GymRatApi.Commands
{
    public class TrainingCreateCommand
    {
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Interval { get; set; }
        public int TrainingDuration { get; set; } = 0;
    }
}
