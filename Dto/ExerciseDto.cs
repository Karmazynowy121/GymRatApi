namespace GymRatApi.Dto
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoDto Video { get; set; }
        public SportDto Sport { get; set; }
        public List<BodyPartDto> BodyParts { get; set; }    
    }
}
