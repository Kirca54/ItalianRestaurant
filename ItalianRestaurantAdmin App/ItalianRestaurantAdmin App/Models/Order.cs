using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItalianRestaurantAdmin_App.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public RestaurantUser User { get; set; }

        public IEnumerable<FoodInOrder> FoodInOrders { get; set; }
    }
}
