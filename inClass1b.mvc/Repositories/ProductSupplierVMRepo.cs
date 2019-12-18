using inClass1b.mvc.Models.FoodStore;
using inClass1b.mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class ProductSupplierVMRepo
    {
        private FoodStoreContext db;

        public ProductSupplierVMRepo(FoodStoreContext db)
        {
            this.db = db;
        }
        public IEnumerable<ProductSupplierVM> GetAll()
        {
            IEnumerable<ProductSupplierVM> esList
             = db.Product.Where(ps => ps.VendorNavigation.Vendor == ps.Vendor)
                 // Assign properties within the 'Select' statement.
                 // Notice how we 'must' use the 'EmployeeStoreVM' type.
                 .Select(ps => new ProductSupplierVM()
                 {
                     ProductId = ps.ProductId,
                     Name = ps.Name,
                     Mfg = ps.Mfg,
                     Price = ps.Price,
                     Vendor = ps.Vendor,
                     // Handle null values. 1st option selected if T otherwise 2nd if F.
                     SupplierEmail = 
                        ps.VendorNavigation.SupplierEmail==null ? "": 
                        ps.VendorNavigation.SupplierEmail
                 });
            return esList;
        }
        public ProductSupplierVM Get(int ProductId, string Vendor)
        {
            // Get Product from ProductRepo.
            ProductRepo productRepo = new ProductRepo(db);
            Product product = productRepo.Get(ProductId);

            // Get Supplier from StoreRepo.
            SupplierRepo supplierRepo = new SupplierRepo(db);
            Supplier supplier = supplierRepo.Get(Vendor);

            // Merge data into custom view model object.
            ProductSupplierVM psVM = new ProductSupplierVM
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Mfg = product.Mfg,
                Price = product.Price,
                Vendor = product.Vendor,
                // Handle null values. 1st option selected if T otherwise 2nd if F.
                SupplierEmail =
                        supplier.SupplierEmail == null ? "" :
                        supplier.SupplierEmail
            };
            return psVM;
        }

        public bool Update(ProductSupplierVM psVM)
        {
            // Updating our ViewModel really requires updates to 
            // two separate tables. 

            // Update the 'Supplier'.
            SupplierRepo supplierRepo = new SupplierRepo(db);
            supplierRepo.Update(psVM.Vendor, psVM.SupplierEmail);

            // Update the 'Product'.
            ProductRepo productRepo = new ProductRepo(db);
            productRepo.Update(psVM.ProductId, psVM.Name, psVM.Mfg, psVM.Vendor, psVM.Price);

            // Error handling could go here and if problems are encountered
            // 'false' could be returned.

            // Otherwise if things go well return true.
            return true;
        }
    }
}
