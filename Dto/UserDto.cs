using GymRatApi.Entieties;

namespace GymRatApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime LastLogin { get; set; }
        public List<UserTrainingScheulde> TrainingScheuldes { get; set; }
    }
}
