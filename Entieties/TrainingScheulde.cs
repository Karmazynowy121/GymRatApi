namespace GymRatApi.Entieties
{
    /// <summary>
    /// Lista treningowa ustawiana przez użytkownika
    /// </summary>
    public class TrainingScheulde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserTrainingScheulde User { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
