using Hospital.DataAccess.Abstract;
using Hospital.DataAccess.EntityFramework.Context;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess.EntityFramework.Concrete
{
    public class ManagerRepo : BaseRepo<Manager>, IManagerRepo
    {
        public ManagerRepo(HospitalDBContext hospitalDBContext) : base(hospitalDBContext)
        {

        }
        public async Task<Manager> GetByEmail(string email, string password)
        {
            var manager = await _table.Where(z => z.EmailAddress == email && z.Password == password).FirstOrDefaultAsync();
            return manager;
        }

    }
}
