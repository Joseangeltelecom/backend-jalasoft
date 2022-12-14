using BakeryFreshBread.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryFreshBread.Infrastructure.Data
{
    public class BakeryFreshBreadContext: DbContext
    {
        public BakeryFreshBreadContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bread> Breads { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BreadOrder> BreadOrders  {get; set; }
        public DbSet<Office> Offices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BakeryFreshBreadDB");
        }
    }
}
