using Restaurant.Domain.Domain;
using Restaurant.Domain.DTO;
using Restaurant.Repository.Interface;
using Restaurant.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Service.Implementation
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _foodRepository;
        private readonly IRepository<FoodInShoppingCart> _foodInShoppingCartRepository;

        private readonly IUserRepository _userRepository;


        public FoodService(IRepository<Food> foodRepository, IUserRepository userRepository, IRepository<FoodInShoppingCart> foodInShoppingCartRepository)
        {
            _foodRepository = foodRepository;
            _userRepository = userRepository;
            _foodInShoppingCartRepository = foodInShoppingCartRepository;
        }

        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {

            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.FoodId != null && userShoppingCard != null)
            {
                var product = this.GetDetailsForFood(item.FoodId);

                if (product != null)
                {
                    FoodInShoppingCart itemToAdd = new FoodInShoppingCart
                    {
                        Food = product,
                        FoodId = product.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._foodInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
                
            }
            return false;
        }

        public void CreateNewFood(Food p)
        {
            this._foodRepository.Insert(p);
        }

        public void DeleteFood(Guid id)
        {
            var food = this.GetDetailsForFood(id);
            this._foodRepository.Delete(food);
        }

        public List<Food> GetAllFoods()
        {
            return this._foodRepository.GetAll().ToList();
        }

        public Food GetDetailsForFood(Guid? id)
        {
            return this._foodRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForFood(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedFood = product,
                FoodId = product.Id,
                Quantity = 1
            };
            return model;
        }

        public void UpdeteExistingFood(Food p)
        {
            this._foodRepository.Update(p);
        }
    }
}
