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
        //[HttpGet]
        //public IActionResult UpdatingManager(Guid id)
        //{
        //    var updatingManager = (Manager)HomeController._myUser.Find(x => x.Id == id);
        //    return View(updatingManager);
        //}
        //[HttpPost]
        //public IActionResult UpdatingManager(Manager manager)
        //{
        //    HomeController._myUser.Remove(HomeController._myUser.Find(x => x.Id == manager.Id));
        //    HomeController._myUser.Add(manager);
        //    return RedirectToAction("ListOfManagers");
        //}
        //public IActionResult DeletingManager(Guid id)
        //{
        //    HomeController._myUser.Remove(HomeController._myUser.Find(x => x.Id == id));
        //    return RedirectToAction("ListOfManagers");
        //}
        //[HttpGet]
        //public IActionResult AddPersonnel()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddPersonnel(Personnel personnel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HomeController._myUser.Add(personnel);
        //        return RedirectToAction("ListOfPersonnels");
        //    }
        //    return View(personnel);
        //}

        //public IActionResult ListOfPersonnels()
        //{
        //    return View(HomeController._myUser);

        //}
        //public IActionResult ListOfPersonnels2()
        //{
        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    foreach (var item in HomeController._myUser)
        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);
        //            return View();
        //        }
        //    }
        //    return View(myPersonnels);

        //}
        //public IActionResult ListOfPersonnels3()
        //{
        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    foreach (var item in HomeController._myUser)
        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);
        //        }
        //    }
        //    ViewBag.ourPersonnels = myPersonnels;
        //    ViewData["ourPersonnels2"] = myPersonnels;
        //    TempData["ourPersonnels3"] = myPersonnels;
        //    return View();
        //}
        //public IActionResult ShowUsAll()
        //{
        //    PersonnelManagerVM personnelManagerVM = new PersonnelManagerVM();

        //    List<Personnel> myPersonnels = new List<Personnel>();
        //    List<Manager> myManagers = new List<Manager>();
        //    foreach (var item in HomeController._myUser)

        //    {
        //        if (item is Personnel)
        //        {
        //            myPersonnels.Add((Personnel)item);
        //        }
        //        if (item is Manager)
        //        {
        //            myManagers.Add((Manager)item);
        //        }
        //    }
        //    personnelManagerVM.PersonnelList = myPersonnels;
        //    personnelManagerVM.ManagerList = myManagers;
        //    return View(personnelManagerVM);
        //}
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
