using TestableAPI.Repositories;

namespace TestableAPI.Services
{
    public class CrudService<T>(ICrudRepository<T> repository) : ICrudService<T> where T : class
    {
        private readonly ICrudRepository<T> repository = repository;
        public async Task<T> CreateAsync(T entity)
        {
            return await repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await repository.ReadAllAsync();
        }

        public async Task<T?> ReadByIdAsync(int id)
        {
            return await repository.ReadByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await repository.UpdateAsync(entity);
        }
    }
}
