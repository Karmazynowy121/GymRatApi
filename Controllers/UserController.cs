using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRatApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {




        private readonly IUserServices _userServices;


        public UserController(IUserServices userServices)
        {

            _userServices = userServices;
        }



        [HttpPut]
        public async Task<IActionResult> CreateUser([FromBody] string name, string email, string password)
        {
            var newUser = _userServices.Create(name, email, password);
            return Ok(newUser);
        }
        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _userServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                return await _userServices.GetById(id);
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
                await _userServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}