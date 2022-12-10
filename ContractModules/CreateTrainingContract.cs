using GymRatApi.Entieties;

namespace GymRatApi.ContractModules
{
    public class CreateTrainingContract
    {
        public List<CreateTrainingPartContract> TrainingParts { get; set; }
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Interval { get; set; }
    }
}
