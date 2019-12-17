using inClass1b.mvc.Models.Portifolio;
using inClass1b.mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class InterviewRequestVMRepo
    {
        private readonly PortfolioContext _context;

        public InterviewRequestVMRepo(PortfolioContext _context)
        {
            this._context = _context;
        }
        public bool Create(InterviewRequestVM irVM)
        {
            return true;
        }

    }
}
