namespace GymRatApi.Entieties
{
    public class BodyPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HowManyExercisesPerWeek { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
