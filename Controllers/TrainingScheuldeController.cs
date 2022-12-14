using GymRatApi.ContractModules;
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
        public async Task<IActionResult> CreateTrainingScheulde([FromBody] CreateTrainingScheuldeContract createTrainingScheuldeContract)
        {
            try
            {
                if (createTrainingScheuldeContract is null)
                {
                    return BadRequest();
                }
                var newTrainingScheulde = await _trainingScheuldeService.Create(createTrainingScheuldeContract);
                return Ok(newTrainingScheulde);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] CreateTrainingScheuldeContract createTrainingScheuldeContract)
        {
            try
            {
                if (createTrainingScheuldeContract == null)
                {
                    return BadRequest("User does not exist");
                }
                await _trainingScheuldeService.Update(createTrainingScheuldeContract);
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
                if (id <= 0)
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
        public async Task<List<TrainingScheulde>> GetAll()
        {
            return await _trainingScheuldeService.GetAll();
        }
    }
}
