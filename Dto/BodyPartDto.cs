using GymRatApi.Entieties;

namespace GymRatApi.Dto
{
    public class BodyPartDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HowManyExercisesPerWeek { get; set; }

        public int ExerciseId { get; set; }
    }
}
