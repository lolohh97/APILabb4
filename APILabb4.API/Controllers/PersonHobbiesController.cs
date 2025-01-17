﻿using APILabb4.API.Services;
using APILabb4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonHobbiesController : ControllerBase
    {
        private IUserHobby<PersonHobby> _personhobby;
        public PersonHobbiesController(IUserHobby<PersonHobby> userHobby)
        {
            _personhobby = userHobby;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonHobbies()
        {
            try
            {
                return Ok(await _personhobby.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve all data from database...");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonHobby(int id)
        {
            try
            {
                var result = await _personhobby.GetSingle(id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve single data from database...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonHobby>> AddNewPH(PersonHobby newPH)
        {
            try
            {
                if (newPH == null)
                {
                    return BadRequest();
                }
                var addedPH = await _personhobby.Add(newPH);
                return CreatedAtAction(nameof(GetPersonHobby), new { id = addedPH.PersonHobbyId }, addedPH);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add in database...");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonHobby>> UpdatePH(int id, PersonHobby ph)
        {
            try
            {
                if (id != ph.PersonHobbyId)
                {
                    return BadRequest("ID does not match...");
                }
                var PHToUpdate = await _personhobby.GetOne(id);
                if (PHToUpdate == null)
                {
                    return NotFound($"ID {id} not found");
                }
                return await _personhobby.Update(ph);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update to database...");
            }
        }
    }
}
