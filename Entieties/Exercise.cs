namespace GymRatApi.Entieties
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Video Video { get; set; }
        public virtual Sport Sport { get; set; }
        public List<BodyPart> Parts {get; set;}
    }
}
