using HrLeaveManagament.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HrLeaveManagementDBContext _dbContext;
        public GenericRepository(HrLeaveManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var result = await _dbContext.Set<T>().FindAsync(Id);
            _dbContext.Set<T>().Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int Id)
        {
            var entity = await GetAsync(Id);
            return entity != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var lstEntity = await _dbContext.Set<T>().ToListAsync();
            return lstEntity;
        }

        public async Task<T> GetAsync(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
