using Microsoft.AspNetCore.Mvc;
using TestableAPI.Models;
using TestableAPI.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(ICrudService<Event> service) : ControllerBase,ICrudController<Event>
    {
        private readonly ICrudService<Event> service = service;
        // GET: api/<EventsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAsync()
        {
            var events = await service.ReadAllAsync();
            return Ok(events);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetAsync(int id)
        {
            var entity = await service.ReadByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<ActionResult<Event>> PostAsync([FromBody] Event entity)
        {
            entity = await service.CreateAsync(entity);
            return Ok(entity);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Event entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await service.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE api/<EventsController>/5
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
