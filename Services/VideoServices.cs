using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class VideoServices : BaseServices, IVideoServices
    {
        public VideoServices(GymDbContext dbContext) 
            : base(dbContext)
        {
        }
        public Task<Video> Create(VideoCreateCommand videoCreateCommand)
        {
            if (videoCreateCommand == null)
            {
                throw new ArgumentNullException("CreateBaseVideoContract is empty");
            }

            var rootExercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == videoCreateCommand.ExerciseId);

            if (rootExercise == null)
            {
                throw new Exception($"Exercise with id: {videoCreateCommand.ExerciseId} does not exist");
            }

            var newVideo = new Video();
            newVideo.Title = videoCreateCommand.Title;
            newVideo.Path = videoCreateCommand.Path;
            newVideo.ExerciseId = videoCreateCommand.ExerciseId;
            newVideo.Exercise = rootExercise;
            _dbContext.Add(newVideo);
            _dbContext.SaveChanges();
            return Task.FromResult(newVideo);
        }
        public Task<List<Video>> GetAll() => Task.FromResult(_dbContext.Videos.ToList());
        public Task<Video> GetById(VideoGetDto videoGetDto)
        {

            var video = _dbContext.Videos.FirstOrDefault(v => v.Id == videoGetDto.Id);
            if (video is null)
            {
                throw new Exception($"video {videoGetDto} not found");
            }
            return Task.FromResult(video);
        }
        public Task Delete(VideoDeleteCommand videoDeleteCommand)
        {
            var video = _dbContext
                .Videos
                .FirstOrDefault(v => v.Id == videoDeleteCommand.Id);
            if (video == null)
                throw new Exception("Video not found");
            _dbContext.Videos.Remove(video);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Update(VideoUpdateCommand videoUpdateCommand)
        {
            _dbContext.Update(videoUpdateCommand); 
            _dbContext.SaveChanges();
            return Task.CompletedTask;
                
        }
    }
}
