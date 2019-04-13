using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Required]
        public string VendorEmail { get; set; }
        [Required]
        public long VendorPhoneNo { get; set; }
        public List<Product> Products { get; set; }
    }
}
