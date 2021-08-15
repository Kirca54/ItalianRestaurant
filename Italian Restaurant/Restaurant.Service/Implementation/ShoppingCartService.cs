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
    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IRepository<ShoppingCart> _shoppingCartRepositorty;
        private readonly IRepository<Order> _orderRepositorty;
        private readonly IRepository<FoodInOrder> _foodInOrderRepositorty;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<EmailMessage> _mailRepository;



        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<FoodInOrder> foodInOrderRepositorty, IRepository<Order> orderRepositorty, IUserRepository userRepository, IRepository<EmailMessage> mailRepository)
        {
            _shoppingCartRepositorty = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepositorty = orderRepositorty;
            _foodInOrderRepositorty = foodInOrderRepositorty;
            _mailRepository = mailRepository;
        }


        public bool deleteFoodFromShoppingCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.FoodInShoppingCarts.Where(z => z.FoodId.Equals(id)).FirstOrDefault();

                userShoppingCart.FoodInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepositorty.Update(userShoppingCart);

                return true;
            }

            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var AllProducts = userShoppingCart.FoodInShoppingCarts.ToList();

            var allProductPrice = AllProducts.Select(z => new
            {
                FoodPrice = z.Food.Price,
                Quanitity = z.Quantity
            }).ToList();

            var totalPrice = 0;


            foreach (var item in allProductPrice)
            {
                totalPrice += item.Quanitity * item.FoodPrice;
            }


            ShoppingCartDto scDto = new ShoppingCartDto
            {
                Foods = AllProducts,
                TotalPrice = totalPrice
            };


            return scDto;
        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                EmailMessage mail = new EmailMessage();
                mail.MailTo = loggedInUser.Email;
                mail.Subject = "Successfully created order";
                mail.Status = false;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepositorty.Insert(order);

                List<FoodInOrder> productInOrders = new List<FoodInOrder>();

                var result = userShoppingCart.FoodInShoppingCarts.Select(z => new FoodInOrder
                {
                    Id = Guid.NewGuid(),
                    FoodId = z.Food.Id,
                    OrderedFood = z.Food,
                    OrderId = order.Id,
                    UserOrder = order,
                    Quantity = z.Quantity
                }).ToList();


                StringBuilder sb = new StringBuilder();

                var totalPrice = 0;

                sb.AppendLine("Your order is completed. The order conains: ");

                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i-1];

                    totalPrice += item.Quantity * item.OrderedFood.Price;

                    sb.AppendLine(i.ToString() + ". " + item.OrderedFood.Name + " with price of: " + item.OrderedFood.Price + " and quantity of: " + item.Quantity);
                }

                sb.AppendLine("Total price: " + totalPrice.ToString());


                mail.Content = sb.ToString();

                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._foodInOrderRepositorty.Insert(item);
                }

                loggedInUser.UserCart.FoodInShoppingCarts.Clear();

                this._mailRepository.Insert(mail);

                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }
    }
}

