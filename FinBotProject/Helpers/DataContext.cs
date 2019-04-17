using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Strategy> Strategy { get; set; }
        public DbSet<UsersBots> UsersBots { get; set; }
        public DbSet<TradingBot> TradingBots { get; set; }
    }
}