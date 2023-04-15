using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInsController : ControllerBaseRollCall
    {
        public CheckInsController(IBusinessLayer rollCallBl) : base(rollCallBl)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckIn checkIn)
        {
            int employeeId;
            int id;

            employeeId = await _rollCallBl.Employee.GetAsync(checkIn.EmployeeNumber);
            if (employeeId == 0)
            {
                return NotFound(new { Message = "Empleado no encontrado" });
            }            

            id = await _rollCallBl.CheckIn.AddAsync(checkIn);

            return Ok(new { Id = id });
        }
    }
}