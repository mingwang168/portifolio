using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b.mvc.Models.FoodStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inClass1b.mvc.Controllers
{
    public class ProductController : Controller
    {
        private FoodStoreContext db;
        public ProductController(FoodStoreContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Product);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = await db.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}