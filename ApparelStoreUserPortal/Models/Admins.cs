using System;
using System.Collections.Generic;

namespace ApparelStoreUserPortal.Models
{
    public partial class Admins
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public long PhoneNumber { get; set; }
        public long AlternatePhoneNumber { get; set; }
        public string Gender { get; set; }
    }
}
