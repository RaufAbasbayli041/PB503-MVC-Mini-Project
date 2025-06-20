using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> Update(T entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsyn(int id);

    }
}
