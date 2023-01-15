using GymRatApi.Commands.BodyPartCommands;
using GymRatApi.Dto;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyPartController : ControllerBase
    {
        private readonly IBodyPartService _bodyPartService;

        public BodyPartController(IBodyPartService bodyPartService)
        {
            _bodyPartService = bodyPartService;
        }
        [HttpPut]
        public async Task<IActionResult> CreateBodyPart([FromBody] BodyPartCreateCommand bodyPartCreateCommand)
        {
            try
            {
                if (bodyPartCreateCommand is null)
                {
                    return BadRequest();
                }
                var newBodyPart = await _bodyPartService.Create(bodyPartCreateCommand);
                return Ok(newBodyPart);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<List<BodyPartDto>> GetAll()
        {
            return await _bodyPartService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyPartDto>> Get([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                return await _bodyPartService.GetById(id);
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
                await _bodyPartService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Update([FromBody] BodyPartUpdateCommand bodyPartUpdateCommand)
        {
            try
            {
                if (bodyPartUpdateCommand == null)
                {
                    return BadRequest("Video is invalid, is null");
                }
                await _bodyPartService.Update(bodyPartUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
