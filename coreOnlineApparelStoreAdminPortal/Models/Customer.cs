using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineApparelStoreAdminPortal.Models
{
    public class Customer
    {    
            public int CustomerId { get; set; }
            public string CustomerFirstName { get; set; }
            public string CustomerLastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Address2 { get; set; }
            public string Country { get; set; }
            public string Country2 { get; set; }
            public string State2 { get; set; }
            public int ZipCode { get; set; }
            public int ZipCode2 { get; set; }
            public bool SameAddress { get; set; }
            public long PhoneNumber { get; set; }
            public long AlternatePhoneNumber { get; set; }
            public string Gender { get; set; }
            public string Password { get; set; }
            public List<Order> Orders { get; set; }
            public Cart Cart { get; set; }
            public List<FeedBack> FeedBacks { get; set; }
            public string State { get; set; }
        }
    }

