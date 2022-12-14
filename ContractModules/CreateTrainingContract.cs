using GymRatApi.Entieties;

namespace GymRatApi.ContractModules
{
    public class CreateTrainingContract
    {
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Interval { get; set; }
        public int TrainingDuration { get; set; } = 0;
    }
}
