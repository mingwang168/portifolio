using inClass1b.mvc.Models.Portifolio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.ViewModels
{
    public class ProjectTechnologiesVM
    {
        public Project Project { get; set; }
        public IEnumerable<Technology> Technologies { get; set; }

    }
}
