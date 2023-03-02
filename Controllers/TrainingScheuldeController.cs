using GymRatApi.Commands.TrainingScheuldeCommands;
using GymRatApi.Dto;
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
        public async Task<IActionResult> CreateTrainingScheulde([FromBody] TrainingScheuldeCreateCommand trainingScheuldeCreateCommand)
        {
            try
            {
                if (trainingScheuldeCreateCommand is null)
                {
                    return BadRequest();
                }
                var newTrainingScheulde = await _trainingScheuldeService.Create(trainingScheuldeCreateCommand);
                return Ok(newTrainingScheulde);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Update([FromBody] TrainingScheuldeUpdateCommand trainingScheuldeUpdateCommand)
        {
            try
            {
                if (trainingScheuldeUpdateCommand == null)
                {
                    return BadRequest("User does not exist");
                }
                await _trainingScheuldeService.Update(trainingScheuldeUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                await _trainingScheuldeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<List<TrainingScheuldeDto>> GetAll()
        {
            return await _trainingScheuldeService.GetAll();
        }
    }
}
