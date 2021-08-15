using Restaurant.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.DTO
{
    public class AddToShoppingCardDto
    {
        public Food SelectedFood { get; set; }
        public Guid FoodId { get; set; }
        public int Quantity { get; set; }
    }
}
