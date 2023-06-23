using System;
using System.Collections.Generic;
using System.Linq;
using OnlinePizzaWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace OnlinePizzaWebApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context, IServiceProvider service)
        {
            context.Database.EnsureCreated();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = service.GetRequiredService<UserManager<IdentityUser>>();

            if (context.Pizzas.Any())
            {
                return;
            }

            ClearDatabase(context);
            CreateAdminRole(context, roleManager, userManager);
            SeedDatabase(context, roleManager, userManager);
        }

        private static void CreateAdminRole(AppDbContext context, RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            bool roleExists = _roleManager.RoleExistsAsync("Admin").Result;
            if (roleExists)
            {
                return;
            }
            
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            _roleManager.CreateAsync(role).Wait();

            var user = new IdentityUser()
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };

            string adminPassword = "Password123";
            var userResult =  _userManager.CreateAsync(user, adminPassword).Result;

            if (userResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        private static void SeedDatabase(AppDbContext _context, RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            var cat1 = new Categories { Name = "Standard", Description = "Pizze Standardowe dostępne sa cały rok." };
            var cat2 = new Categories { Name = "Specjalne", Description = "Pizze Specjalne dostępne są w określonym czasie" };
            var cat3 = new Categories { Name = "Nowe", Description = "Nowe Pizze w naszym menu" };

            var cats = new List<Categories>()
            {
                cat1, cat2, cat3
            };

            var piz1 = new Pizzas { Name = "Capricciosa", Price = 40.00M, Category = cat1, Description = "Normalna włoska Pizza.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Pizza_capricciosa.jpg", IsPizzaOfTheWeek = false };
            var piz2 = new Pizzas { Name = "Wegetariańska", Price = 20.00M, Category = cat3, Description = "Pizza dla wegetarianinów", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Vegetarian_pizza.jpg", IsPizzaOfTheWeek = false };
            var piz3 = new Pizzas { Name = "Hawajska", Price = 50.00M, Category = cat1, Description = "Pizza z ananasem.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Hawaiian_pizza_1.jpg", IsPizzaOfTheWeek = true };
            var piz4 = new Pizzas { Name = "Margarita", Price = 25.00M, Category = cat2, Description = "Klasyczna pizza.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg", IsPizzaOfTheWeek = false };
            var piz5 = new Pizzas { Name = "Kebab", Price = 45.00M, Category = cat2, Description = "Pizza Kebab.", ImageUrl = "http://2.bp.blogspot.com/_3cSn3Qz_4IA/THkYqKwGw1I/AAAAAAAAAPg/ybKpvRbjDWE/s1600/matsl%C3%A4kten+002.JPG", IsPizzaOfTheWeek = true };
            var piz6 = new Pizzas { Name = "Pescatore", Price = 30.00M, Category = cat3, Description = "Pizza z owocami morza.", ImageUrl = "https://isinginthekitchen.files.wordpress.com/2014/07/dsc_0231.jpg", IsPizzaOfTheWeek = true };
           

            var pizs = new List<Pizzas>()
            {
                piz1, piz2, piz3, piz4, piz5, piz6
            };

            var user1 = new IdentityUser { UserName = "user1@gmail.com", Email = "user1@gmail.com" };
            var user2 = new IdentityUser { UserName = "user2@gmail.com", Email = "user2@gmail.com" };
            var user3 = new IdentityUser { UserName = "user3@gmail.com", Email = "user3@gmail.com" };
            var user4 = new IdentityUser { UserName = "user4@gmail.com", Email = "user4@gmail.com" };
            var user5 = new IdentityUser { UserName = "user5@gmail.com", Email = "user5@gmail.com" };

            string userPassword = "Password123";

            var users = new List<IdentityUser>()
            {
                user1, user2, user3, user4, user5
            };

            foreach (var user in users)
            {
                _userManager.CreateAsync(user, userPassword).Wait();
            }

            var revs = new List<Reviews>()
            {
                new Reviews { User = user1, Title ="Najlepsza pizza", Description="Kocham tą pizze.", Grade=4, Date=DateTime.Now, Pizza = piz1 },
                new Reviews { User = user2, Title ="Najgorsza pizza", Description="Bardzo nie dobra Pizza.", Grade=1, Date=DateTime.Now.AddDays(-1), Pizza = piz1 },
                new Reviews { User = user2, Title ="Coś pysznego", Description="Polecam wszystkim wege.", Grade=5, Date=DateTime.Now, Pizza = piz2 },
                new Reviews { User = user3, Title ="Drogo", Description="Drogie ceny za Pizze.", Grade=2, Date=DateTime.Now.AddDays(-6), Pizza = piz2 },
                new Reviews { User = user5, Title ="Super", Description="Specjalne Pizze są najlepsze!", Grade=5, Date=DateTime.Now.AddDays(-9), Pizza = piz5 },
            };

            

            var ord1 = new Order
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                AddressLine1 = "MainStreet 12",
                City = "Kraków",
                Email = "jankowalski@gmail.com",
                OrderPlaced = DateTime.Now.AddDays(-2),
                PhoneNumber = "372971424",
                User = user1,
                ZipCode = "34200",
                OrderTotal = 140.00M,
            };

            var ord2 = new Order { };
            var ord3 = new Order { };

            var orderLines = new List<OrderDetail>()
            {
                new OrderDetail { Order=ord1, Pizza=piz1, Amount=2, Price=piz1.Price},
                new OrderDetail { Order=ord1, Pizza=piz3, Amount=1, Price=piz3.Price},
                new OrderDetail { Order=ord1, Pizza=piz5, Amount=3, Price=piz5.Price},
            };

            var orders = new List<Order>()
            {
                ord1
            };

            _context.Categories.AddRange(cats);
            _context.Pizzas.AddRange(pizs);
            _context.Reviews.AddRange(revs);
            _context.Orders.AddRange(orders);
            _context.OrderDetails.AddRange(orderLines);
            

            _context.SaveChanges();
        }

        private static void ClearDatabase(AppDbContext _context)
        {
            var reviews = _context.Reviews.ToList();
            _context.Reviews.RemoveRange(reviews);

            var shoppingCartItems = _context.ShoppingCartItems.ToList();
            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            foreach (var user in users)
            {
                if (!userRoles.Any(r => r.UserId == user.Id))
                {
                    _context.Users.Remove(user);
                }
            }

            var orderDetails = _context.OrderDetails.ToList();
            _context.OrderDetails.RemoveRange(orderDetails);

            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);

            var pizzas = _context.Pizzas.ToList();
            _context.Pizzas.RemoveRange(pizzas);

            var categories = _context.Categories.ToList();
            _context.Categories.RemoveRange(categories);

            _context.SaveChanges();
        }
    }
}
