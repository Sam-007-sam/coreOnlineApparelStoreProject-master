using System;
using System.Collections.Generic;

namespace CoreApparelManagerPortal.Models
{
    public partial class Carts
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ItemCreated { get; set; }

        public Customers Customer { get; set; }
        public Products Product { get; set; }
    }
}
