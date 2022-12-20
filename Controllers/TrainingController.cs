using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        [HttpPut]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingCreateCommand trainingCreateCommand)
        {
            try
            {
                if (trainingCreateCommand is null)
                {
                    return BadRequest();
                }
                var newTraining = await _trainingService.Create(trainingCreateCommand);
                return Ok(newTraining);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
