namespace GymRatApi.Dto
{
    public class TrainingScheuldeDto 
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<TrainingDto> Training { get; set; }
    }
}
