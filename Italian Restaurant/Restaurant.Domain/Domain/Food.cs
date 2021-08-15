using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Domain
{
    public class Food : BaseEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public String Image { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public int Rating { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<FoodInShoppingCart> FoodInShoppingCarts { get; set; }

        public IEnumerable<FoodInOrder> FoodInOrders { get; set; }


    }
}
