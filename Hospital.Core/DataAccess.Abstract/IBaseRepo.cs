namespace Hospital.Core.DataAccess.Abstract
{
    public interface IBaseRepo<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> AddRange(List<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<int> Save();

    }
}
