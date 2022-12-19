using GymRatApi.Commands;
using GymRatApi.Entieties;
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
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] TrainingScheuldeUpdateCommand trainingScheuldeUpdateCommand)
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
        public async Task<ActionResult> Delete([FromRoute] TrainingScheuldeDeleteCommand trainingScheuldeDeleteCommand)
        {
            try
            {
                if (trainingScheuldeDeleteCommand is null)
                {
                    return BadRequest();
                }
                await _trainingScheuldeService.Delete(trainingScheuldeDeleteCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<List<TrainingScheulde>> GetAll()
        {
            return await _trainingScheuldeService.GetAll();
        }
    }
}
