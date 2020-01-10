using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portifolio.mvc.Models.Portifolio;
using portifolio.mvc.Repositories;
using portifolio.mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Portfolio.mvc.Controllers
{
    public class InterviewRequestController : Controller
    {
        private readonly PortfolioContext _context;

        public InterviewRequestController(PortfolioContext _context)
        {
            this._context = _context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InterviewRequestVM irVM)
        {
            new InterviewRequestVMRepo(_context).Create(irVM);
            return RedirectToAction("Index", "Home");
        }
    }
}