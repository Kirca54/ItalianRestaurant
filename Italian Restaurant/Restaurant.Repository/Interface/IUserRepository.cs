using Restaurant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<RestaurantUser> GetAll();
        RestaurantUser Get(string id);
        void Insert(RestaurantUser entity);
        void Update(RestaurantUser entity);
        void Delete(RestaurantUser entity);
    }
}
