using Restaurant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Domain
{
    public class ShoppingCart : BaseEntity
    {
        public virtual ICollection<FoodInShoppingCart> FoodInShoppingCarts { get; set; }

        public string OwnerId { get; set; }
        public RestaurantUser Owner { get; set; }
    }
}
