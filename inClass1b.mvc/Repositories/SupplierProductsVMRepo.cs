using inClass1b.mvc.Models.FoodStore;
using inClass1b.mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class SupplierProductsVMRepo
    {
        private readonly FoodStoreContext db;

        public SupplierProductsVMRepo(FoodStoreContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierProductsVM> GetAll()
        {
            return db.Supplier.Select(s => new SupplierProductsVM()
            {
                Supplier = s,
                Products = s.Product
            });
        }

        public SupplierProductsVM GetDetails(string vendor)
        {
            return GetAll().FirstOrDefault(sp => sp.Supplier.Vendor == vendor);
        }

        public SupplierProductsVM Get(string vendor)
        {
            return GetAll().FirstOrDefault(sp => sp.Supplier.Vendor == vendor);
        }

        public bool Update(SupplierProductsVM spVM)
        {
            // Updating our ViewModel really requires updates to 
            // two separate tables. 

            // Update the 'Supplier'.
            SupplierRepo supplierRepo = new SupplierRepo(db);
            supplierRepo.UpdateFromSupplier(spVM.Supplier);

            // Update the 'Product'.
            //ProductRepo productRepo = new ProductRepo(db);
            //productRepo.UpdateFromSupplier(spVM.Products);

            // Error handling could go here and if problems are encountered
            // 'false' could be returned.

            // Otherwise if things go well return true.
            return true;
        }
    }
}
