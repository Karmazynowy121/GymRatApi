using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Dto;
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
        [HttpGet]
        public async Task<List<TrainingDto>> GetAll()
        {
            return await _trainingService.GetAll();
        }
        [HttpPost]
        public async Task<ActionResult> Update([FromBody] TrainingUpdateCommand trainingUpdateCommand)
        {
            try
            {
                if (trainingUpdateCommand == null)
                {
                    return BadRequest("Training does not exist");
                }
                await _trainingService.Update(trainingUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
