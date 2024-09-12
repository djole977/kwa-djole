using KWA_Djole.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace KWA_Djole.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CustomerCart> CustomerCarts { get; set; }
        public DbSet<ShoppingItemGenre> ShoppingItemGenres { get; set; }
        public DbSet<UserGenres> UserGenres { get; set; }
    }
}