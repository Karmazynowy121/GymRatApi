namespace GymRatApi.Entieties
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
