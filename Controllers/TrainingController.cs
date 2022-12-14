using GymRatApi.ContractModules;
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
        public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingContract createTrainingContract)
        {
            try
            {
                if (createTrainingContract is null)
                {
                    return BadRequest();
                }
                var newTraining = await _trainingService.Create(createTrainingContract);
                return Ok(newTraining);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
