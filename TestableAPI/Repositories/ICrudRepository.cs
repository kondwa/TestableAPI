namespace TestableAPI.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> ReadAllAsync();
        Task<T?> ReadByIdAsync(int id);
        
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
