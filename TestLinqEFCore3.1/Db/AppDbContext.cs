using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestLinqEFCore3._1.Db.Models;

namespace TestLinqEFCore3._1.Db
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<Type> Types { set; get; }
        public virtual DbSet<ProductType> ProductTypes { set; get; }
    }
}
