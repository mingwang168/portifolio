using portifolio.mvc.Models.Portifolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portifolio.mvc.ViewModels
{
    public class ProjectTechnologiesVM
    {
        public Project Project { get; set; }
        public IEnumerable<Technology> Technologies { get; set; }
    }
}
