using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Message { get; set; }
      
    }
}
