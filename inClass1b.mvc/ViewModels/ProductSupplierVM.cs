using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.ViewModels
{
    public class ProductSupplierVM
    {
        [DisplayName("Product ID")] // Give nice label name for CRUD.
        public int ProductId { get; set; }
        [DisplayName("Name")]   // Give nice label name for CRUD.
        public string Name { get; set; }
        public string Mfg { get; set; }
        public decimal? Price { get; set; }
        public string Vendor { get; set; }
        public string SupplierEmail { get; set; }
    }
}
