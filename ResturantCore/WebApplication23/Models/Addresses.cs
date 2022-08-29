using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication23.Models
{
    public partial class Addresses
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string States { get; set; }
        public int? ResturantId { get; set; }

        public virtual Resturant Resturant { get; set; }
    }
}
