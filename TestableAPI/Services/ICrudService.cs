using System.Collections;

namespace TestableAPI.Services
{
    public interface ICrudService<T> where T : class
    {
        Task<IEnumerable<T>> ReadAllAsync();
        Task<T?> ReadByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
