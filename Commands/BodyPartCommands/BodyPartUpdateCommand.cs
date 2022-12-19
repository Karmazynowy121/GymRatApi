using GymRatApi.Entieties;

namespace GymRatApi.Commands.BodyPartCommands
{
    public class BodyPartUpdateCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HowManyExercisesPerWeek { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
