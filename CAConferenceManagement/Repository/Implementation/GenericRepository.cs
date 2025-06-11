using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly ConferenceDB _conferenceDB;

        private readonly DbSet<T> _dbSet;
        public GenericRepository(ConferenceDB conferenceDB)
        {
            _conferenceDB = conferenceDB;
            _dbSet = _conferenceDB.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _conferenceDB.SaveChangesAsync();
            return entity;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _dbSet.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            data.IsDeleted = true;
            _dbSet.Update(data);
            await _conferenceDB.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var datas = await _dbSet.Where(i => i.IsDeleted == false).AsNoTracking<T>().ToListAsync();
            return datas;
        }

        public async Task<T> GetByIdAsyn(int id)
        {

            var data = await _dbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
            return data;
        }

        public async Task<T> Update(T entity)
        {
            entity.Updated = DateTime.Now;
            _dbSet.Update(entity);
            await _conferenceDB.SaveChangesAsync();
            return entity;
        }
    }
}
