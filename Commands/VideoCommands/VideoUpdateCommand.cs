using GymRatApi.Entieties;

namespace GymRatApi.Commands.VideoCommands
{
    public class VideoUpdateCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
