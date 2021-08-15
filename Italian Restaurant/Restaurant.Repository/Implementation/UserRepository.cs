using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Identity;
using Restaurant.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<RestaurantUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<RestaurantUser>();
        }
        public IEnumerable<RestaurantUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public RestaurantUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.FoodInShoppingCarts")
               .Include("UserCart.FoodInShoppingCarts.Food")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(RestaurantUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(RestaurantUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(RestaurantUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }


    }
}
