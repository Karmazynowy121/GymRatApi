using GymRatApi.Commands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
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
        public async Task<List<BodyPart>> GetAll()
        {
            return await _bodyPartService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyPart>> Get([FromRoute] BodyPartGetDto bodyPartGetDto)
        {
            try
            {
                if (bodyPartGetDto is null)
                {
                    return BadRequest();
                }
                return await _bodyPartService.GetById(bodyPartGetDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] BodyPartDeleteCommand bodyPartDeleteCommand)
        {
            try
            {
                if (bodyPartDeleteCommand is null)
                {
                    return BadRequest();
                }
                await _bodyPartService.Delete(bodyPartDeleteCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] BodyPartUpdateCommand bodyPartUpdateCommand)
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
