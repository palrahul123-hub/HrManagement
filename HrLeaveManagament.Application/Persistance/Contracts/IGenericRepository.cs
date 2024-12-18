namespace HrLeaveManagament.Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}
