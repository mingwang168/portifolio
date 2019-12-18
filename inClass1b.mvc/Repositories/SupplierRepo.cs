using inClass1b.mvc.Models.FoodStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class SupplierRepo
    {
        private FoodStoreContext db;

        public SupplierRepo(FoodStoreContext db)
        {
            this.db = db;
        }
        public Supplier Get(string vendor)
        {
            return db.Supplier.FirstOrDefault(s => s.Vendor == vendor);
        }
        public bool Update(string vendor, string supplierEmail)
        {
            Supplier supplier = db.Supplier
                .FirstOrDefault(s => s.Vendor == vendor);
            // Remember you can't update the primary key without 
            // causing trouble.  
            supplier.SupplierEmail = supplierEmail;
            db.SaveChanges();
            return true;
        }
    }
}
