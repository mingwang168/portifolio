using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b.mvc.Models.Portifolio;
using inClass1b.mvc.Repositories;
using inClass1b.mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inClass1b.mvc.Controllers
{
    public class ProjectTechnologiesController : Controller
    {
        private readonly PortfolioContext _db;

        public ProjectTechnologiesController(PortfolioContext db)
        {
            _db = db;
        }
                
        public IActionResult Index()
        {
            //var results = _db.ProjectTechnologies.Include(pt => pt.Project).Include(pt => pt.Technology);
            //return View(results);
            return View(new ProjectTechnologiesVMRepo(_db).GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(new ProjectTechnologiesVMRepo(_db).GetDetails(id));
        }

        public IActionResult InterviewRequests()
        {
            return RedirectToAction("Create", "InterviewRequests");
        }
    }
}