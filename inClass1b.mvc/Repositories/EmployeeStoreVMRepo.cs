using inClass1b.mvc.Models.FoodStore;
using inClass1b.mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class EmployeeStoreVMRepo
    {
        private FoodStoreContext db;

        public EmployeeStoreVMRepo(FoodStoreContext db)
        {
            this.db = db;
        }

        public IEnumerable<EmployeeStoreVM> GetAll()
        {

            IEnumerable<EmployeeStoreVM> esList
                = db.Employee.Where(es => es.BranchNavigation.Branch == es.Branch)
                    // Assign properties within the 'Select' statement.
                    // Notice how we 'must' use the 'EmployeeStoreVM' type.
                    .Select(es => new EmployeeStoreVM()
                    {
                        EmployeeID = es.EmployeeId,
                        LastName = es.LastName,
                        FirstName = es.FirstName,
                        Branch = es.Branch,
                        Region = es.BranchNavigation.Region,

                        // Handle null values. 1st option selected if T otherwise 2nd if F.
                        BuildingName =
                            es.BranchNavigation.BuildingName == null ? "" :
                            es.BranchNavigation.BuildingName,

                        // Must handle null because a null exists for 
                        // unit_num in the database.
                        // Get integer if it exists otherwise get 0.
                        UnitNum = es.BranchNavigation.UnitNum == null ? 0 :
                    (int)es.BranchNavigation.UnitNum
                    });
            return esList;
        }
        public EmployeeStoreVM Get(int employeeID, string branch)
        {
            // Get Employee from EmployeeRepo.
            EmployeeRepo employeeRepo = new EmployeeRepo(db);
            Employee employee = employeeRepo.Get(employeeID);

            // Get Store from StoreRepo.
            StoreRepo storeRepo = new StoreRepo(db);
            Store store = storeRepo.Get(branch);

            // Merge data into custom view model object.
            EmployeeStoreVM esVM = new EmployeeStoreVM
            {
                EmployeeID = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Branch = store.Branch,
                BuildingName = store.BuildingName == null ? "" : store.BuildingName,
                Region = store.Region,
                // Need condition to handle null
                UnitNum = store.UnitNum == null ? 0 : (int)store.UnitNum
            };
            return esVM;
        }

        public bool Update(EmployeeStoreVM esVM)
        {
            // Updating our ViewModel really requires updates to 
            // two separate tables. 

            // Update the 'Store'.
            StoreRepo storeRepo = new StoreRepo(db);
            storeRepo.Update(esVM.Branch, esVM.Region);

            // Update the 'Employee'.
            EmployeeRepo empRepo = new EmployeeRepo(db);
            empRepo.Update(esVM.EmployeeID, esVM.FirstName, esVM.LastName);

            // Error handling could go here and if problems are encountered
            // 'false' could be returned.

            // Otherwise if things go well return true.
            return true;
        }

    }
}
