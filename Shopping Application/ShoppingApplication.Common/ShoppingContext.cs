using Microsoft.EntityFrameworkCore;
using ShoppingApplication.Common.Models;

namespace ShoppingApplication.Common
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
