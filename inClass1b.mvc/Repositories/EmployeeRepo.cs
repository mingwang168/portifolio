using inClass1b.mvc.Models.FoodStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class EmployeeRepo
    {
        private FoodStoreContext db;

        public EmployeeRepo(FoodStoreContext db)
        {
            this.db = db;
        }

        public Employee Get(int id)
        {
            return db.Employee.FirstOrDefault(e => e.EmployeeId == id);
        }

        public bool Update(int id, string first, string last)
        {
            Employee employee = db.Employee
                .FirstOrDefault(e => e.EmployeeId == id);
            // Remember you can't update the primary key without 
            // causing trouble.  Just update the first and last names
            // for now.
            employee.FirstName = first;
            employee.LastName = last;
            db.SaveChanges();
            return true;
        }


    }
}
