using EY.BankApp.Web.Data.Configurations;
using EY.BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EY.BankApp.Web.Data.Context
{
    public class BankContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public BankContext(DbContextOptions<BankContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
