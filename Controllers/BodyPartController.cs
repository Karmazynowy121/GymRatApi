﻿using GymRatApi.ContractModules;
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
        public async Task<IActionResult> CreateBodyPart([FromBody] CreateBodyPartContract createBodyPartContract)
        {
            try
            {
                if (createBodyPartContract is null)
                {
                    return BadRequest();
                }
                var newBodyPart = await _bodyPartService.Create(createBodyPartContract.Name,
                    createBodyPartContract.HowManyExercisePerWeek,
                    createBodyPartContract.ExerciseId);
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
        public async Task<ActionResult<BodyPart>> Get([FromRoute] int id)
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
        [HttpPatch]
        public async Task<ActionResult> Update([FromRoute] BodyPart bodyPart)
        {
            try
            {
                if (bodyPart == null)
                {
                    return BadRequest("Video is invalid, is null");
                }
                await _bodyPartService.Update(bodyPart);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}