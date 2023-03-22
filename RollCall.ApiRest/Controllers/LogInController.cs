using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBaseRollCall
    {
        public LogInController(IBusinessLayer rollCallBl) : base(rollCallBl)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserLoginDto userLogin)
        {
            TokenDto tokenDto;

            tokenDto = await _rollCallBl.Login.LoginAsync(userLogin);
            if (tokenDto == null)
            {
                NotFound(new { Message = "Credenciales no validas" });
            }

            return Ok(tokenDto);
        }
    }
}
