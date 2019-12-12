using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b.mvc.Models.FoodStore;
using inClass1b.mvc.Models.Portifolio;
using inClass1b.mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace inClass1b.mvc.Controllers
{
    public class ProjectTechnologiesController : Controller
    {
        private PortfolioContext db;
        public ProjectTechnologiesController(PortfolioContext db)
        {
            this.db = db;
        }
        [Route("mingwang")]
        public IActionResult Index()
        {
            return View(db.ProjectTechnologies);
        }

        public IActionResult Details(int id)
        {
            return View(new ProjectTechnologiesVMRepo(db).Get(id));
        }
    }
}