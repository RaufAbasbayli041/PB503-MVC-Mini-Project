using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Service.Interface
{
    public interface IGenericService<TModel, TEntity> where TModel : class where TEntity : BaseEntity
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> Update(TModel model);
        Task<bool> DeleteAsync(int id);
    }
    
}
