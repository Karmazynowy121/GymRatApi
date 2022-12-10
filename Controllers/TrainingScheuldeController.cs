using GymRatApi.ContractModules;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingScheuldeController : ControllerBase
    {
        private readonly ITrainingScheuldeService _trainingScheuldeService;

        public TrainingScheuldeController(ITrainingScheuldeService trainingScheuldeService)
        {
            _trainingScheuldeService = trainingScheuldeService;
        }
        [HttpPut]
        public async Task<IActionResult> CreateTrainingScheulde([FromBody] CreateTrainingScheuldeContract createTrainingScheuldeContract)
        {
            try
            {
                if (createTrainingScheuldeContract is null)
                {
                    return BadRequest();
                }
                var newTrainingScheulde = _trainingScheuldeService.Create(createTrainingScheuldeContract.User,
                   createTrainingScheuldeContract.Training);
                return Ok(newTrainingScheulde);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
