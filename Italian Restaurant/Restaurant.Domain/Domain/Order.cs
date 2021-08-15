using Restaurant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public RestaurantUser User { get; set; }

        public IEnumerable<FoodInOrder> FoodInOrders { get; set; }
    }
}
