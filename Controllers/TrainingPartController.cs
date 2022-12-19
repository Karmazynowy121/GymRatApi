using GymRatApi.Commands;
using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPartController : ControllerBase
    {
        private readonly ITrainingPartServices _trainingPartServices;

        public TrainingPartController(ITrainingPartServices trainingPartServices)
        {
            _trainingPartServices = trainingPartServices;
        }
        [HttpPut]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingPartCreateCommand trainingPartCreateCommand)
        {
            try
            {
                if (trainingPartCreateCommand is null)
                {
                    return BadRequest();
                }
                var newTrainingPart = _trainingPartServices.Create(trainingPartCreateCommand); 
                return Ok(newTrainingPart);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<List<TrainingPart>> GetAll()
        {
            return await _trainingPartServices.GetAll();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] TrainingPartDeleteCommand trainingPartDeleteCommand)
        {
            try
            {
                if (trainingPartDeleteCommand is null)
                {
                    return BadRequest();
                }
                await _trainingPartServices.Delete(trainingPartDeleteCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] TrainingPartUpdateCommand trainingPartUpdateCommand)
        {
            try
            {
                if (trainingPartUpdateCommand == null)
                {
                    return BadRequest("Video is invalid, is null");
                }
                await _trainingPartServices.Update(trainingPartUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
