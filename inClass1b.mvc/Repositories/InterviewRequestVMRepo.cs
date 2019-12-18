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
        private readonly PortfolioContext db;

        public InterviewRequestVMRepo(PortfolioContext db)
        {
            this.db = db;
        }
        public bool Create(InterviewRequestVM irVM)
        {
            if (db.Companies.FirstOrDefault(c => c.Name == irVM.Company) == null)
            {
                db.Companies.Add(new Company
                {
                    Name = irVM.Company,
                    Contact = irVM.Contact,
                    Phone = irVM.Phone,
                    Email = irVM.Email
                });

                db.SaveChanges();

                db.InterviewRequests.Add(new InterviewRequest
                {
                    Time = irVM.Time,
                    Location = irVM.Location,
                    Company = db.Companies.FirstOrDefault(c => c.Name == irVM.Company)
                });

                db.SaveChanges();
            }
            else
            {
                db.InterviewRequests.Add(new InterviewRequest
                {
                    Time = irVM.Time,
                    Location = irVM.Location,
                    Company = db.Companies.FirstOrDefault(c => c.Name == irVM.Company)
                });

                db.SaveChanges();
            }

            return true;
        }

    }
}
