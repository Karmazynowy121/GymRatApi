using GymRatApi.Commands;
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
                var newVideo = _videoServices.Create(videoCreateCommand);
                return Ok(newVideo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
        }
        [HttpGet]
        public async Task<List<Video>> GetAll()
        {
            return await _videoServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> Get([FromRoute] VideoGetDto videoGetDto)
        {
            try
            {
                if (videoGetDto is null)
                {
                    return BadRequest();
                }
                return await _videoServices.GetById(videoGetDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] VideoDeleteCommand videoDeleteCommand)
        {
            try
            {
                if (videoDeleteCommand is null)
                {
                    return BadRequest();
                }
                await _videoServices.Delete(videoDeleteCommand);
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
