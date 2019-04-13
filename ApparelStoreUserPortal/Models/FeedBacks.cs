using System;
using System.Collections.Generic;

namespace ApparelStoreUserPortal.Models
{
    public partial class FeedBacks
    {
        public int FeedBackId { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }

        public Customers Customer { get; set; }
    }
}
