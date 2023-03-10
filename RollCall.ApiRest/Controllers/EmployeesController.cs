using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos;
using RollCall.Core.Interfaces;

namespace RollCall.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBaseRollCall
    {
        public EmployeesController(IBusinessLayer rollCallBl) : base(rollCallBl)
        {
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagerDtoIn pagerDtoIn)
        {
            PagerDto pager;

            pager = await _rollCallBl.Employee.GetAsync(pagerDtoIn);

            return Ok(pager);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDto> Get(int id)
        {
            EmployeeDto employeeDto;

            employeeDto = await _rollCallBl.Employee.GetAsync(id);

            return employeeDto;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDtoIn employee)
        {
            int id;

            id = await _rollCallBl.Employee.AddAsync(employee);

            return Created($"Employees/{id}", new { Id = id });
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDtoIn employee)
        {
            await _rollCallBl.Employee.UpdateAsync(employee, id);

            return Accepted(new { Message = "Datos actualizados" });
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rollCallBl.Employee.DeleteAsync(id);

            return Accepted(new { Message = $"Empleado {id} borrado" });
        }
        
    }//end class
}