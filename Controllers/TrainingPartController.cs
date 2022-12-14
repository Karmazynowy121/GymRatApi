using GymRatApi.ContractModules;
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
        public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingPartContract createTrainingPartContract)
        {
            try
            {
                if (createTrainingPartContract is null)
                {
                    return BadRequest();
                }
                var newTrainingPart = _trainingPartServices.Create(createTrainingPartContract); 
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
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                await _trainingPartServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] TrainingPart trainingPart)
        {
            try
            {
                if (trainingPart == null)
                {
                    return BadRequest("Video is invalid, is null");
                }
                await _trainingPartServices.Update(trainingPart);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
