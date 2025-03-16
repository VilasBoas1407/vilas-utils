using Vilas.Utils.Domain;

namespace Vilas.Utils.Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid Id);
        Task<T> GetAsync(Guid Id);
        Task<bool> ExistAsync(Guid Id);
        Task<List<T>> GetAllAsync();
    }
}
