using GymRatApi.Commands.ExerciseCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseServices _exerciseServices;
        public ExerciseController(IExerciseServices exerciseServices)
        {
            _exerciseServices = exerciseServices;
        }

        [HttpPut]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseCreateCommand exerciseCreateCommand)
        {
            var newExercise = await _exerciseServices.Create(exerciseCreateCommand);
            return Ok(newExercise);
        }
        [HttpGet]
        public async Task<List<ExerciseDto>> GetAll()
        {
            return await _exerciseServices.GetAll();
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<Exercise>> GetExerciseById(int id)
        {
            return await _exerciseServices.GetbyId(id);
        }

        [HttpGet("{name}")]
        public async Task <ActionResult<ExerciseDto>> Get([FromRoute] string name)
        {
            try
            {
                if (name == null)
                {
                    return BadRequest();
                }

                return await _exerciseServices.GetbyName(name);
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
                await _exerciseServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
