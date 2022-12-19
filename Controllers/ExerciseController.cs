using GymRatApi.Commands;
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
        public async Task <IActionResult> CreateExercise([FromBody] ExerciseCreateCommand exerciseCreateCommand)
        {
            var newExercise = await _exerciseServices.Create(exerciseCreateCommand);
            return Ok(newExercise);
        }
        [HttpGet]
        public async Task <List<Exercise>> GetAll()
        {
          return await _exerciseServices.GetAll();
        }
        [HttpGet("{name}")]
        public async Task <ActionResult<Exercise>> Get([FromRoute] ExerciseGetDto exerciseGetDto)
        {
            try
            {
                if (exerciseGetDto == null)
                {
                    return BadRequest();
                }

                return await _exerciseServices.GetbyName(exerciseGetDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] ExerciseDeleteCommand exerciseDeleteCommand)
        {
            try
            {
                if (exerciseDeleteCommand is null)
                {
                    return BadRequest();
                }
                await _exerciseServices.Delete(exerciseDeleteCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
