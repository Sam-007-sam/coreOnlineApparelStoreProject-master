using System;
using System.Collections.Generic;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public partial class OrderProducts
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
