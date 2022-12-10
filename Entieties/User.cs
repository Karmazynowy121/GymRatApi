namespace GymRatApi.Entieties
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime LastLogin { get; set; }
        public int TrainingScheuldeId { get; set; }
        public TrainingScheulde TrainingScheulde { get; set; }
    }
}
