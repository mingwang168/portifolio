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
    public class SupplierProductsController : Controller
    {
        private readonly FoodStoreContext _db;

        public SupplierProductsController(FoodStoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var results = _db.ProjectTechnologies.Include(pt => pt.Project).Include(pt => pt.Technology);
            //return View(results);
            return View(new SupplierProductsVMRepo(_db).GetAll());
        }
        public IActionResult Details(string vendor)
        {
            return View(new SupplierProductsVMRepo(_db).GetDetails(vendor));
        }

        // This method is called when the user arrives at the edit page.
        [HttpGet]
        public ActionResult Edit(string vendor)
        {
            SupplierProductsVMRepo spRepo = new SupplierProductsVMRepo(_db);
            SupplierProductsVM spVM = spRepo.Get(vendor);
            return View(spVM);
        }

        // This method is called when the user clicks the submit
        // button from the edit page.
        [HttpPost]
        public ActionResult Edit(SupplierProductsVM spVM)
        {
            SupplierProductsVMRepo spRepo = new SupplierProductsVMRepo(_db);
            spRepo.Update(spVM);

            // go to index action method of the same controller.
            // return RedirectToAction("Index");
            // go to index action method of the Home controller with parameters.
            return RedirectToAction("Index", "SupplierProducts");

        }
    }
}