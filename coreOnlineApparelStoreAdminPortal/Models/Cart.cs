using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public class Cart
    {
        [Column(Order = 0), Key, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public DateTime ItemCreated { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
