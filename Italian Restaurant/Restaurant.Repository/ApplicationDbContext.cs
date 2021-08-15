using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Domain;
using Restaurant.Domain.Identity;
using System;

namespace Restaurant.Repository
{
    public class ApplicationDbContext : IdentityDbContext<RestaurantUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<FoodInShoppingCart> FoodInShoppingCarts { get; set; }
        public virtual DbSet<FoodInOrder> FoodInOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Food>().
                Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>().
                Property(z => z.Id)
                .ValueGeneratedOnAdd();
/*
            builder.Entity<FoodInShoppingCart>()
              .HasKey(z => new { z.FoodId, z.ShoppingCartId });*/

            builder.Entity<FoodInShoppingCart>()
               .HasOne(z => z.Food)
               .WithMany(z => z.FoodInShoppingCarts)
               .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<FoodInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.FoodInShoppingCarts)
                .HasForeignKey(z => z.FoodId);


            builder.Entity<ShoppingCart>()
               .HasOne<RestaurantUser>(z => z.Owner)
               .WithOne(z => z.UserCart)
               .HasForeignKey<ShoppingCart>(z => z.OwnerId);



           /* builder.Entity<FoodInOrder>()
               .HasKey(z => new { z.FoodId, z.OrderId });
*/
            builder.Entity<FoodInOrder>()
                .HasOne(z => z.OrderedFood)
                .WithMany(z => z.FoodInOrders)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<FoodInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.FoodInOrders)
                .HasForeignKey(z => z.FoodId);
        }
    }
}
