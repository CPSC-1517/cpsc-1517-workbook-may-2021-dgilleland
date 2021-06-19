using Microsoft.EntityFrameworkCore;
using SimpleDatabase.Entities;

namespace SimpleDatabase.DAL
{
    public class WestWindContext : DbContext
    {
        public WestWindContext(DbContextOptions<WestWindContext> options)
            : base(options)
        {
            // Nothing to see here folks....
        }

        public DbSet<ProductItem> Items { get; set; }
    }
}