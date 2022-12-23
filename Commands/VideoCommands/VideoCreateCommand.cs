using GymRatApi.Entieties;

namespace GymRatApi.Commands.VideoCommands
{
    public class VideoCreateCommand
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public int ExerciseId { get; set; }
    }
}
