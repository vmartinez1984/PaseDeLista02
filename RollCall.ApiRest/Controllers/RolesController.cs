using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBaseRollCall
    {
        public RolesController(IBusinessLayer rollCallBl) : base(rollCallBl)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<RoleDto> roles;

            roles = await _rollCallBl.Role.GetAsync();

            return Ok(roles);
        }
    }
}
