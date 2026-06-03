using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairManagementStudio.DataAccessLayer
{
    public class AutoRepairDA : DbContext
    {
        public AutoRepairDA(AutoRepairContext context)
        {
            this.Context = context;
        }

        protected AutoRepairContext Context { get; set; }


        #region CfgSetting

        #endregion CfgSetting

        #region Account
        public Account? GetAccountByUsername(string username)
        {
            return Context.Accounts.FirstOrDefault(u => u.username == username);
        }

        public void AccountFailedLogin(int AccountId)
        {
            Account? user = Context.Accounts.FirstOrDefault(u => u.account_id == AccountId);
            if (user == null) return;

            CfgSetting? setting = Context.CfgSettings.FirstOrDefault(u => u.name == "account lockout threshold");
            if (int.TryParse(setting?.value, out int attemptThreshold) == false)
            {
                attemptThreshold = 5; //default
            }

            user.password_attempt_count += 1;
            if (user.password_attempt_count >= attemptThreshold) // Assuming 5 attempts before lockout
            {
                user.is_locked = true;
                user.locked_at = DateTimeOffset.UtcNow;
            }
            Context.SaveChanges();
        }
        #endregion Account

        #region Vehicle
        public List<Vehicle> GetAllVehiclesByAccountId(int AccountId)
        {
            return Context.Vehicles.Where(x => x.account_id == AccountId).ToList();
        }
        #endregion Vehicle

        #region WorkOrder
        public List<ActiveWorkOrder> GetAllActiveWorkOrders()
        {
            return Context.ActiveWorkOrders.ToList();
        }
        #endregion WorkOrder

    }
}
