using System;
using System.Collections.Generic;

namespace ApparelStoreUserPortal.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            OrderProducts = new HashSet<OrderProducts>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductSize { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }
        public int BrandId { get; set; }

        public Brands Brand { get; set; }
        public Categories Category { get; set; }
        public Vendors Vendor { get; set; }
        public ICollection<Carts> Carts { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
