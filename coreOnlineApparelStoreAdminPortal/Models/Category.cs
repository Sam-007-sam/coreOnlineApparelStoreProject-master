using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public class Category
    {     
            public int CategoryId { get; set; }
            [Required]
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }
            public List<Product> Products { get; set; }

    }
}
