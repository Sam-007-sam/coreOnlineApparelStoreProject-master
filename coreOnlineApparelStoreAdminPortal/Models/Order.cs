using System;
using System.Collections.Generic;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
