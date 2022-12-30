using Hospital.DataAccess.Abstract;
using Hospital.DataAccess.EntityFramework.Context;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess.EntityFramework.Concrete
{
    public class PersonnelRepo : BaseRepo<Personnel>, IPersonnelRepo
    {
        public PersonnelRepo(HospitalDBContext hospitalDBContext) : base(hospitalDBContext)
        {

        }
        public async Task<Personnel> GetByEmail(string email, string password)
        {
            var personnel = await _table.Where(z => z.EmailAddress == email && z.Password == password).FirstOrDefaultAsync();
            return personnel;
        }
    }
}
