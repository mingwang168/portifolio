using inClass1b.mvc.Models.FoodStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Repositories
{
    public class ProductRepo
    {
        private FoodStoreContext db;

        public ProductRepo(FoodStoreContext db)
        {
            this.db = db;
        }
        public Product Get(int id)
        {
            return db.Product.FirstOrDefault(p => p.ProductId == id);
        }
        public Product GetAll(string vendor)
        {
            return db.Product.FirstOrDefault(p => p.Vendor == vendor);
        }
        public bool Update(int id, string name, string mfg, string vendor, decimal? price)
        {
            Product product = db.Product
                .FirstOrDefault(p => p.ProductId == id);
            // Remember you can't update the primary key without 
            // causing trouble.  
            product.Name = name;
            product.Mfg = mfg;
            product.Vendor = vendor;
            product.Price = price;
            db.SaveChanges();
            return true;
        }
        //public bool UpdateFromSupplier(IEnumerable<Product> products)
        //{
        //    Employee employee = db.Employee
        //        .FirstOrDefault(e => e.EmployeeId == id);
        //    // Remember you can't update the primary key without 
        //    // causing trouble.  Just update the first and last names
        //    // for now.
        //    employee.FirstName = first;
        //    employee.LastName = last;
        //    db.SaveChanges();
        //    return true;
        //}
    }
}
