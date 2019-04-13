using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreUserPortal.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime ItemCreated { get; set; }
       public Products Products { get; set; }
    }
}
