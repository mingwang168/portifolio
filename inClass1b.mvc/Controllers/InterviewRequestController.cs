using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b.mvc.Models.Portifolio;
using inClass1b.mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Portfolio.Controllers
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
            return RedirectToAction("Index", "Home");
        }
    }
}