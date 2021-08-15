using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Identity
{
    public class RestaurantUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
