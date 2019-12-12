using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b.mvc.Models.FoodStore;
using inClass1b.mvc.Repositories;
using inClass1b.mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace inClass1b.mvc.Controllers
{
    public class EmployeeStoreController : Controller
    {
        private FoodStoreContext db;

        public EmployeeStoreController(FoodStoreContext db)
        {
            this.db = db;
        }

        public ActionResult Index(string fName, string lName, string email, int reps)
        {
            EmployeeStoreVMRepo esRepo = new EmployeeStoreVMRepo(db);
            IEnumerable<EmployeeStoreVM> es = esRepo.GetAll();
            return View(es);
        }
        public ActionResult Details(int employeeID, string branch)
        {
            EmployeeStoreVMRepo esRepo = new EmployeeStoreVMRepo(db);
            EmployeeStoreVM esVM = esRepo.Get(employeeID, branch);
            return View(esVM);
        }
        // This method is called when the user arrives at the edit page.
        [HttpGet]
        public ActionResult Edit(int employeeID, string branch)
        {
            EmployeeStoreVMRepo esRepo = new EmployeeStoreVMRepo(db);
            EmployeeStoreVM esVM = esRepo.Get(employeeID, branch);
            return View(esVM);
        }

        // This method is called when the user clicks the submit
        // button from the edit page.
        [HttpPost]
        public ActionResult Edit(EmployeeStoreVM esVM)
        {
            EmployeeStoreVMRepo esRepo = new EmployeeStoreVMRepo(db);
            esRepo.Update(esVM);

            // go to index action method of the same controller.
            // return RedirectToAction("Index");
            // go to index action method of the Home controller with parameters.
            return RedirectToAction("Index", "Home",
                new { fName = "Phil", lName = "Weier", email = "pweier@my.bcit.ca", reps = 1 });

        }


    }
}