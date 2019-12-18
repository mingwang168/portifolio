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
    public class ProductSupplierController : Controller
    {
        private FoodStoreContext db;

        public ProductSupplierController(FoodStoreContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ProductSupplierVMRepo psRepo = new ProductSupplierVMRepo(db);
            IEnumerable<ProductSupplierVM> ps = psRepo.GetAll();
            return View(ps);
        }
        public ActionResult Details(int productId, string vendor)
        {
            ProductSupplierVMRepo psRepo = new ProductSupplierVMRepo(db);
            ProductSupplierVM psVM = psRepo.Get(productId, vendor);
            return View(psVM);
        }

        // This method is called when the user arrives at the edit page.
        [HttpGet]
        public ActionResult Edit(int productId, string vendor)
        {
            ProductSupplierVMRepo psRepo = new ProductSupplierVMRepo(db);
            ProductSupplierVM psVM = psRepo.Get(productId, vendor);
            return View(psVM);
        }

        // This method is called when the user clicks the submit
        // button from the edit page.
        [HttpPost]
        public ActionResult Edit(ProductSupplierVM psVM)
        {
            ProductSupplierVMRepo psRepo = new ProductSupplierVMRepo(db);
            psRepo.Update(psVM);

            // go to index action method of the same controller.
            // return RedirectToAction("Index");
            // go to index action method of the Home controller with parameters.
            return RedirectToAction("Index", "ProductSupplier");

        }
    }
}