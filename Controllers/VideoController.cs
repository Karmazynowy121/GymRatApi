using GymRatApi.Commands.VideoCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoServices _videoServices;

        public VideoController(IVideoServices videoServices)
        {
            _videoServices = videoServices;
        }

        [HttpPut]
        public async Task<IActionResult> CreateVideo([FromBody] VideoCreateCommand videoCreateCommand)
        {
            try
            {
                if (videoCreateCommand is null)
                {
                    return BadRequest();
                }
                var newVideo = await _videoServices.Create(videoCreateCommand);
                return Ok(newVideo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
        }
        [HttpGet]
        public async Task<List<VideoDto>> GetAll()
        {
            return await _videoServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoDto>> Get([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                return await _videoServices.GetById(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                await _videoServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute]VideoUpdateCommand videoUpdateCommand)
        {
            try
            {
                if (videoUpdateCommand == null)
                {
                    return BadRequest("Video is invalid, is null");
                }
                await _videoServices.Update(videoUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
