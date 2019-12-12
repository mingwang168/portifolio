using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b.mvc.Models.FoodStore;
using Microsoft.AspNetCore.Mvc;

namespace inClass1b.mvc.Controllers
{
    public class BuildingController : Controller
    {
        // Create context.
        private FoodStoreContext db;
        public BuildingController(FoodStoreContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Building);
        }
    }
}