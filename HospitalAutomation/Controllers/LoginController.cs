using Hospital.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminRepo _adminRepo;
        private readonly IManagerRepo _managerRepo;
        private readonly IPersonnelRepo _personnelRepo;
        public LoginController(IAdminRepo adminRepo, IManagerRepo managerRepo, IPersonnelRepo personnelRepo)
        {
            _adminRepo = adminRepo;
            _managerRepo = managerRepo;
            _personnelRepo = personnelRepo;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string emailaddress, string password)
        {
            var adminUser = _adminRepo.GetByEmail(emailaddress, password);
            var managerUser = _managerRepo.GetByEmail(emailaddress, password);
            var personnelUser = _personnelRepo.GetByEmail(emailaddress, password);

            if (adminUser != null) { return RedirectToAction("Index", "Admin"); }
            if (managerUser != null) { return RedirectToAction("Index", "Manager"); }
            if (personnelUser != null) { return RedirectToAction("Index", "Personnel"); }

            return View();

        }
    }
}
