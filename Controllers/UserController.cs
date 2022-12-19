using GymRatApi.Commands;
using GymRatApi.Dto;
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
        public async Task<IActionResult> CreateUser([FromBody] UserCreateCommand userCreateCommand)
        {
            var newUser = _userServices.Create(userCreateCommand);
            return Ok(newUser);
        }
        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _userServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get([FromRoute] UserGetDto userGetDto)
        {
            try
            {
                if (userGetDto is null)
                {
                    return BadRequest();
                }
                return await _userServices.GetById(userGetDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] UserDeleteCommand userDeleteCommand)
        {
            try
            {
                if (userDeleteCommand is null)
                {
                    return BadRequest();
                }
                await _userServices.Delete(userDeleteCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]

        public async Task<ActionResult> Update([FromRoute] UserUpdateCommand userUpdateCommand)
        {
            try
            {
                if (userUpdateCommand == null)
                {
                    return BadRequest("User does not exist");
                }
                await _userServices.Update(userUpdateCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}