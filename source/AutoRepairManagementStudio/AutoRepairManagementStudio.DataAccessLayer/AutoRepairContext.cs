using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairManagementStudio.DataAccessLayer
{
    public sealed class AutoRepairContext : DbContext
    {
        public AutoRepairContext(DbContextOptions<AutoRepairContext> options)
            : base(options)
        {
        }

        #region Cfg Tables
        public DbSet<CfgSetting> CfgSettings { get; set; }
        public DbSet<CfgStatus> CfgStatuses { get; set; }
        #endregion Cfg Tables

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderExpense> WorkOrderExpenses { get; set; }

        #region Views
        public DbSet<WorkOrderView> WorkOrderViews { get; set; }
        #endregion Views

        //public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    }
        //}

    }
}
