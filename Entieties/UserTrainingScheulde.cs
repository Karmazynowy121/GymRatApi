namespace GymRatApi.Entieties
{
    public class UserTrainingScheulde
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TrainingScheuldeId { get; set; }
        public TrainingScheulde TrainingScheulde { get; set; }
    }
}
