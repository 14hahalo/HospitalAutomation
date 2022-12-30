using Hospital.DataAccess.Abstract;
using Hospital.DataAccess.EntityFramework.Context;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess.EntityFramework.Concrete
{
    public class AdminRepo : BaseRepo<Admin>, IAdminRepo
    {
        public AdminRepo(HospitalDBContext hospitalDBContext) : base(hospitalDBContext)
        {

        }
        public async Task<Admin> GetByEmail(string email, string password)
        {
            var admin = await _table.Where(z => z.EmailAddress == email && z.Password == password).FirstOrDefaultAsync();
            return admin;
        }

    }
}
