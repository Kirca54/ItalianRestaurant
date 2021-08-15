using Restaurant.Domain.Domain;
using Restaurant.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Service.Interface
{
    public interface IFoodService
    {
        List<Food> GetAllFoods();
        Food GetDetailsForFood(Guid? id);
        void CreateNewFood(Food p);
        void UpdeteExistingFood(Food p);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void DeleteFood(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
    }
}
