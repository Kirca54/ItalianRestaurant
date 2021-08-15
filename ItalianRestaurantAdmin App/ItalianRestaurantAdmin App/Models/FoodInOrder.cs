using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItalianRestaurantAdmin_App.Models
{
    public class FoodInOrder
    {
        public Guid FoodId { get; set; }
        public Food OrderedFood { get; set; }

        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }

    }
}
