using System;
using System.Collections.Generic;

namespace CoreApparelManagerPortal.Models
{
    public partial class Vendors
    {
        public Vendors()
        {
            Products = new HashSet<Products>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public long VendorPhoneNo { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
