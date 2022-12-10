namespace GymRatApi.Entieties
{
    /// <summary>
    /// Lista treningowa ustawiana przez użytkownika
    /// </summary>
    public class TrainingScheulde
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
