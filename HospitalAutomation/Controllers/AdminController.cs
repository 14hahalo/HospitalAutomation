using Hospital.DataAccess.Abstract;
using Hospital.Entities.Concrete;
using HospitalAutomation.Models.DTOs;
using HospitalAutomation.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IManagerRepo _managerRepo;
        public AdminController(IManagerRepo managerRepo)
        {
            _managerRepo = managerRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddManager()
        {
            return View(); // Burası yönetici ekleme sayfatsını açacak olan HTTPGET!!
        }
        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
        {
            Manager addManager = new Manager();
            if (ModelState.IsValid)
            {
                addManager.Id = addManagerDTO.Id;
                addManager.LastName = addManagerDTO.LastName;
                addManager.FirstName = addManagerDTO.FirstName;
                addManager.Salary = addManagerDTO.Salary;
                addManager.EmailAddress = addManagerDTO.EmailAddress;
                addManager.Status = addManagerDTO.Status;
                addManager.CreatedDate = addManagerDTO.CreatedDate;
                addManager.Password = createPassword();

                await _managerRepo.Add(addManager);
                return RedirectToAction("ListOfManagers");
            }
            return View(addManagerDTO);
        }
        public async Task<IActionResult> ListOfManagers()
        {
            var managerList = await _managerRepo.GetAll();

            ListOfManagersVM listOfManagersVMs = new ListOfManagersVM();

            listOfManagersVMs.Managers = managerList;

            return View(listOfManagersVMs);
        }
        
        [NonAction]
        private string createPassword()
        {
            Random rand = new Random();
            string password = String.Empty;

            for (int i = 1; i <= 6; i++)
            {
                int char1 = rand.Next(65, 91);
                password += (char)char1;
            }
            return password;
        }
    }

}
