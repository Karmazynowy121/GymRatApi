namespace GymRatApi.Entieties
{
    /// <summary>
    /// Rozpiska treningu użytkownika 
    /// </summary>
    public class Training
    {
        public int Id { get; set; }
        public string Description { get; set; } //Plecy + klata
        public DateTime TrainingDate { get; set; }
        public int TrainingDuration { get; set; }
        public int Interval { get; set; } // co ile idni
        public int TrainingScheuldeId { get; set; }
        public TrainingScheulde TrainingScheulde { get; set; }
        public List<TrainingPart> TrainingParts { get; set; }// podciaganie martwy wioslowanie/wyciskanie na klate
    }
}
