using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBaseRollCall
    {
        public HolidaysController(IBusinessLayer rollCallBl) : base(rollCallBl)
        {
        }

        // GET: api/<HolidaysController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<HolidayDto> list;

            list = await _rollCallBl.Holiday.GetAsync();

            return Ok(list);
        }

        // GET api/<HolidaysController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HolidayDto holiday;

            holiday = await _rollCallBl.Holiday.GetAsync(id);

            return Ok(holiday);
        }

        // POST api/<HolidaysController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HolidayDtoIn holiday)
        {
            int id;

            id = await _rollCallBl.Holiday.AddAsync(holiday);

            return Created($"/Holidays/{id}", new { Id = id });
        }

        // PUT api/<HolidaysController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HolidayDtoIn holiday)
        {
            await _rollCallBl.Holiday.UpdateAsync(holiday, id);

            return Accepted(new { Message = "Datos Actualizados" });
        }

        // DELETE api/<HolidaysController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rollCallBl.Holiday.DeleteAsync(id);

            return Accepted(new { Message = "Datos Borrados" });
        }
    }
}
