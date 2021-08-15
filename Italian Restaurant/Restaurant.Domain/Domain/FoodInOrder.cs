using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Domain
{
    public class FoodInOrder : BaseEntity
    {
        public Guid FoodId { get; set; }
        public Food OrderedFood { get; set; }

        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }
    }
}
