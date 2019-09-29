using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
             : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Strategy> Strategy { get; set; }
        public DbSet<TradingBot> TradingBots { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<BotsAssets> BotsAssets { get; set; }
    }

}