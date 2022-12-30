using Hospital.Core.DataAccess.Abstract;
using Hospital.Entities.Concrete;

namespace Hospital.DataAccess.Abstract
{
    public interface IAdminRepo : IBaseRepo<Admin>
    {
        Task<Admin> GetByEmail(string email, string password);
    }
}
