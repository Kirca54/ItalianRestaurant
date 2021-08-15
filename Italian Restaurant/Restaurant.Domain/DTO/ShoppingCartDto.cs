using Restaurant.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<FoodInShoppingCart> Foods { get; set; }
        public double TotalPrice { get; set; }
    }
}
