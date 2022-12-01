namespace GymRatApi.Entieties
{
    public class TrainingPart
    {
        public int Id { get; set; }
        public virtual List<Exercise> Exercise {get; set;}
        public int AmountSeries {get; set;}
        public int BodyWeight {get; set;}
    }
}
