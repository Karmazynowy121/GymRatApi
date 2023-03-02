using AutoMapper;
using GymRatApi.Commands.VideoCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;

namespace GymRatApi.Services
{
    public class VideoServices : BaseServices, IVideoServices
    {
        private readonly IMapper _mapper;
        public VideoServices(GymDbContext dbContext, IMapper mapper) 
            : base(dbContext)
        {
            _mapper = mapper;
        }
        public Task<VideoDto> Create(VideoCreateCommand videoCreateCommand)
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
            return Task.FromResult(_mapper.Map<VideoDto>(newVideo));
        }
        public Task<List<VideoDto>> GetAll() 
            => Task.FromResult(_mapper.Map <List<VideoDto>> (_dbContext.Videos.ToList()));
        public Task<VideoDto> GetById(int id)
        {

            var video = _dbContext.Videos.FirstOrDefault(v => v.Id == id);
            if (video is null)
            {
                throw new Exception($"video {id} not found");
            }
            return Task.FromResult(_mapper.Map<VideoDto>(video));
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
        public Task Update(VideoUpdateCommand videoUpdateCommand)
        {
            var video = _mapper.Map<Video>(videoUpdateCommand);
            _dbContext.Update(video); 
            _dbContext.SaveChanges();
            return Task.CompletedTask;
                
        }
    }
}
