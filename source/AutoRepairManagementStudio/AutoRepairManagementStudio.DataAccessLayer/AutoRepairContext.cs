using AutoRepairManagementStudio.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairManagementStudio.DataAccessLayer
{
    public sealed class AutoRepairContext : DbContext
    {
        public AutoRepairContext(DbContextOptions<AutoRepairContext> options)
            : base(options)
        {
        }

        public DbSet<Account> AppUsers { get; set; }
        public DbSet<CfgSetting> CfgSettings { get; set; }

        public void onconfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Fallback to a default connection string if not configured
                optionsBuilder.UseNpgsql("Host=localhost;Database=AutoRepairDB;Username=postgres;Password=yourpassword");
            }
        }

    }
}
