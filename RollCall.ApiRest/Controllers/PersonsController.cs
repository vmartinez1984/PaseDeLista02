﻿using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IBusinessLayer _rollCallBl;

        public PersonsController(IBusinessLayer rollCallBl)
        {
            _rollCallBl = rollCallBl;
        }

        // GET: api/<PersonsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagerDtoIn pagerDtoIn)
        {
            PagerDto pagerDto;

            pagerDto = await _rollCallBl.Person.GetAsync(pagerDtoIn);
            //throw new Exception("Valio pepino");

            return Ok(pagerDto);
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PersonDto person;

            person = await _rollCallBl.Person.GetAsync(id);

            return Ok(person);
        }

        // POST api/<PersonsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDtoIn person)
        {
            int id;

            id = await _rollCallBl.Person.AddAsync(person);
            //id = 1;

            return Created($"/Persons/{id}", new { Id = id });
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonDtoIn person)
        {
            await _rollCallBl.Person.UpdateAsync(person, id);

            return Accepted(new { Message = "Datos actualizados" });
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rollCallBl.Person.DeleteAsync(id);

            return Accepted(new { Mensaje = "Datos borrados" });
        }
    }

    public class ControllerBaseRollCall: ControllerBase
    {
        protected readonly IBusinessLayer _rollCallBl;

        public ControllerBaseRollCall(IBusinessLayer rollCallBl)
        {
            _rollCallBl = rollCallBl;
        }
    }
}
