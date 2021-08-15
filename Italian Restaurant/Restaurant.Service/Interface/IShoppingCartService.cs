using Restaurant.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteFoodFromShoppingCart(string userId, Guid id);
        bool orderNow(string userId);
    }
}
