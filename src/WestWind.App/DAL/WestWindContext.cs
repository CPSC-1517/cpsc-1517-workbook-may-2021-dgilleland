using Microsoft.EntityFrameworkCore;
using WestWind.App.Entities;

namespace WestWind.App.DAL
{
    public class WestWindContext : DbContext
    {
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {
        }

        public DbSet<Shipper> Shippers {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Supplier> Suppliers {get;set;}
    }
}