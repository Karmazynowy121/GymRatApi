using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class VideoServices : BaseServices, IVideoServices
    {
        public VideoServices(GymDbContext dbContext) 
            : base(dbContext)
        {
        }
        public Task<Video> Create (string title, string path, int exerciseId)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(path) || exerciseId < 0)
            {
                throw new ArgumentNullException("Title Or Path is empty");
            }

            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == exerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {exerciseId} does not exist");
            }

            var newVideo = new Video();
            newVideo.Title = title;
            newVideo.Path = path;
            newVideo.ExerciseId = exerciseId;
            newVideo.Exercise = rootExercise;
            _dbContext.Add(newVideo);
            _dbContext.SaveChanges();
            return Task.FromResult(newVideo);
        }
        public Task<List<Video>> GetAll() => Task.FromResult(_dbContext.Videos.ToList());
        public Task<Video> GetById(int id)
        {

            var video = _dbContext.Videos.FirstOrDefault(v => v.Id == id);
            if (video is null)
            {
                throw new Exception($"video {id} not found");
            }
            return Task.FromResult(video);
        }
        public Task Delete(int id)
        {
            var video = _dbContext
                .Videos
                .FirstOrDefault(v => v.Id == id);
            if (video == null)
                throw new Exception("Video not found");
            _dbContext.Videos.Remove(video);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Update(Video video)
        {
            _dbContext.Update(video); 
            _dbContext.SaveChanges();
            return Task.CompletedTask;
                
        }
    }
}
