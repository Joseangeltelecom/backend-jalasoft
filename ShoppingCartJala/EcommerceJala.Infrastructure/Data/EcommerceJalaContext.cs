using EcommerceJala.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceJala.Infrastructure.Data
{
    public class EcommerceJalaContext: DbContext
    {
        public EcommerceJalaContext(DbContextOptions options): base(options)
        {  
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EcommerceJala");
        }
    }
}