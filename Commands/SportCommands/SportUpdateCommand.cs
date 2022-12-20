using GymRatApi.Entieties;

namespace GymRatApi.Commands.SportCommands
{
    public class SportUpdateCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
