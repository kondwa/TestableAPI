using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestableAPI.Controllers
{
    public interface ICrudController<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> GetAsync();

        public Task<ActionResult<T>> GetAsync(int id);

        public Task<ActionResult<T>> PostAsync([FromBody] T entity);
        public Task<ActionResult> PutAsync(int id, [FromBody] T entity);

        public Task<ActionResult> DeleteAsync(int id);
    }
}
