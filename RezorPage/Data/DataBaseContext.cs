using Microsoft.EntityFrameworkCore;
using RezorPage.Models;

namespace RezorPage.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
                
        }
        public DbSet<Product>Products { get; set; }
    }
}