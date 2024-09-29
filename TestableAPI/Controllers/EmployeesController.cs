using Microsoft.AspNetCore.Mvc;
using TestableAPI.Models;
using TestableAPI.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ICrudService<Employee> service) : ControllerBase,ICrudController<Employee>
    {
        private readonly ICrudService<Employee> service = service;
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAsync()
        {
            var employees = await service.ReadAllAsync();
            return Ok(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetAsync(int id)
        {
            var employee = await service.ReadByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostAsync([FromBody] Employee employee)
        {
             employee = await service.CreateAsync(employee);
            return Ok(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Employee employee)
        {
            if(id != employee.Id) {
                return BadRequest(); 
            }
            await service.UpdateAsync(employee);
            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await service.ReadByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            await service.DeleteAsync(id); 
            return NoContent();
        }
    }
}
