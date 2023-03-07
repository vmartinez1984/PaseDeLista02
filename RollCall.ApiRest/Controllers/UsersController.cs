using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBaseRollCall
    {
        public UsersController(IBusinessLayer rollCallBl) : base(rollCallBl)
        {
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UserDto> list;

            list = await _rollCallBl.User.GetAsync();

            return Ok(list);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDto userDto;

            userDto = await _rollCallBl.User.GetAsync(id);
            if (userDto == null)
            {
                return NotFound(new
                {
                    Message = "Usuario no encontrado"
                });
            }

            return Ok(userDto);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDtoIn user)
        {
            int id;

            //id = await _rollCallBl.User.AddAsync(user);
            id = 1984;

            return Created($"Users/{id}", new { Id = id });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDtoIn user)
        {
            await _rollCallBl.User.UpdateAsync(user, id);

            return Accepted(new { Message = "Datos actualizados" });
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rollCallBl.User.DeleteAsync(id);

            return Accepted(new { Message = "Usuario Borrado" });
        }
    }
}
