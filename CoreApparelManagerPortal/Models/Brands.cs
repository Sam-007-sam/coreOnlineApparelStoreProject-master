using System;
using System.Collections.Generic;

namespace CoreApparelManagerPortal.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
