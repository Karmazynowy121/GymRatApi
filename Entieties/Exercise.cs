namespace GymRatApi.Entieties
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TrainingPart TrainingPart { get; set;}
        public Video Video { get; set; }
        public Sport Sport { get; set; }
        public List<BodyPart> BodyParts {get; set;}
    }
}
