using Hospital.Core.DataAccess.Abstract;
using Hospital.Core.Entities.Abstract;
using Hospital.Core.Enums;
using Hospital.DataAccess.EntityFramework.Context;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess.EntityFramework.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly HospitalDBContext _hospitalDbContext;
        protected DbSet<T> _table;

        public BaseRepo(HospitalDBContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
            _table = _hospitalDbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> AddRange(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return await Save() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            entity.Status = Status.Passive;
            return await Save() > 0;
        }

        public async Task<List<T>> GetAll() => await _table.Where(x => x.Status == Status.Active).ToListAsync();


        public async Task<T> GetById(Guid id) => await _table.FindAsync(id);

        public async Task<int> Save()
        {
            return await _hospitalDbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _hospitalDbContext.Entry<T>(entity).State = EntityState.Modified;
            return await Save() > 0;
        }
    

    }
}
