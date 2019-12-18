using inClass1b.mvc.Models.FoodStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.ViewModels
{
    public class SupplierProductsVM
    {
        public Supplier Supplier { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
