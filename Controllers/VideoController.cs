using GymRatApi.ContractModules;
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
        public async Task<IActionResult> CreateVideo([FromBody]CreateBaseVideoContract createBaseVideoContract)
        {
            try
            {
                if (createBaseVideoContract is null)
                {
                    return BadRequest();
                }
                var newVideo = _videoServices.Create(createBaseVideoContract);
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
        public async Task<ActionResult<Video>> Get([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
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
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
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
        public async Task<ActionResult> Update([FromRoute]Video video)
        {
            try
            {
                if (video == null)
                {
                    return BadRequest("Video is invalid, is null");
                }
                await _videoServices.Update(video);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
