using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestableAPI.Models;
using TestableAPI.Services;

namespace TestableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController(ICrudService<Salary> service) : ControllerBase, ICrudController<Salary>
    {
        private readonly ICrudService<Salary> service = service;
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await service.ReadByIdAsync(id);
            if(entity == null)
            {
                return NotFound();
            }
            await service.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetAsync()
        {
            var entities = await service.ReadAllAsync();
            return Ok(entities);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetAsync(int id)
        {
            var entity = await service.ReadByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        [HttpPost]
        public async Task<ActionResult<Salary>> PostAsync([FromBody] Salary entity)
        {
           entity = await service.CreateAsync(entity);
            return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Salary entity)
        {
            if(id != entity.Id)
            {
                return BadRequest();
            }
            await service.UpdateAsync(entity);
            return NoContent();
        }
    }
}
