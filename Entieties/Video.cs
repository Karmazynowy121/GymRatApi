using System.Text.Json.Serialization;

namespace GymRatApi.Entieties
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
