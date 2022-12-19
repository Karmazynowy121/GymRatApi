using GymRatApi.ContractModules;
using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportController : ControllerBase
    {
        private readonly ISportServices _sportServices;

        public SportController(ISportServices sportServices)
        {
            _sportServices = sportServices;
        }
        [HttpPut]
        public async Task<IActionResult> CreateSport([FromBody] SportCreateCommand createSportCommand)
        {
            try
            {
                if (createSportCommand is null)
                {
                    return BadRequest();
                }
                var newSport = await _sportServices.Create(createSportCommand);
                return Ok(newSport);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        public async Task<List<SportDto>> GetAll()
        {
            return await _sportServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SportDto>> Get([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                return await _sportServices.GetById(id);
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
                await _sportServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] SportUpdateCommand sportUpdateCommand)
        {
            try
            {
                if (sportUpdateCommand == null)
                {
                    return BadRequest("sport is invalid, is null");
                }
                await _sportServices.Update(sportUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
