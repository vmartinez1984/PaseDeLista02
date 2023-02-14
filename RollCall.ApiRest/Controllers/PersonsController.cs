using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get()
        {
            List<PersonDto> list;

            list = await _rollCallBl.Person.GetAsync();

            return Ok(list);
        }

        //// GET api/<PersonsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PersonsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PersonsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PersonsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
