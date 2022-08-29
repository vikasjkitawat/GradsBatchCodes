using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication23.Models
{
    public partial class Resturant
    {
        public Resturant()
        {
            Items = new HashSet<Items>();
        }

        public int ResturantId { get; set; }
        public string ResturantName { get; set; }

        public virtual Addresses Addresses { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
