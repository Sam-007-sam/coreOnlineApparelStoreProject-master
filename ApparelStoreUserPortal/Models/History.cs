using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreUserPortal.Models
{
    public class History
    {
        public int HistoryId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
