using portifolio.mvc.Models.Portifolio;
using portifolio.mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portifolio.mvc.Repositories
{
    public class ProjectTechnologiesVMRepo
    {
        private readonly PortfolioContext db;

        public ProjectTechnologiesVMRepo(PortfolioContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProjectTechnologiesVM> GetAll()
        {
            return db.Projects.Select(p => new ProjectTechnologiesVM()
            {
                Project = p,
                Technologies = p.ProjectTechnologies.Select(t => t.Technology)
            });
        }

        public ProjectTechnologiesVM GetDetails(int id)
        {
            return GetAll().FirstOrDefault(pt => pt.Project.ProjectId == id);
        }
    }
}
