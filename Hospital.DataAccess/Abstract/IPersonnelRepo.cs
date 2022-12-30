using Hospital.Core.DataAccess.Abstract;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Abstract
{
    public interface IPersonnelRepo:IBaseRepo<Personnel>
    {
        Task<Personnel> GetByEmail(string email, string password);
    }
}
