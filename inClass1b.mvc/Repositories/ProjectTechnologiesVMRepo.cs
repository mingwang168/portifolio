using inClass1b.mvc.Models.Portifolio;
using inClass1b.mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class ProjectTechnologiesVMRepo
    {
        private readonly PortfolioContext _db;
        public ProjectTechnologiesVMRepo(PortfolioContext db)
        {
            _db = db;
        }

        private IEnumerable<ProjectTechnologiesVM> GetAll()
        {
            return _db.Projects
                .Select(p => new ProjectTechnologiesVM
                {
                    Project = p,
                    Technologies = p.ProjectTechnologies
                   .Select(t => t.Technology)
                });
        }

        public IEnumerable<ProjectTechnologiesVM> Sort(string sortOrder, string searchString)
        {
            var results = GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results
                    .Where(pt => pt.Project.Title.ToLower().Contains(searchString.ToLower())
                    || pt.Technologies.Any(t => t.Name.ToLower().Contains(searchString.ToLower())));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    results = results.OrderByDescending(r => r.Project.Title);
                    break;
                case "description_asc":
                    results = results.OrderBy(r => r.Project.Description);
                    break;
                case "description_desc":
                    results = results.OrderByDescending(r => r.Project.Description);
                    break;
                default:
                    results = results.OrderBy(r => r.Project.Title);
                    break;
            }
            return results;
        }

        public ProjectTechnologiesVM Get(int projId)
        {
            return GetAll()
                    .FirstOrDefault(p => p.Project.ProjectId == projId);
        }
    }
}
