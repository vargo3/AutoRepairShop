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


        #region Cfg
        public CfgStatus[] GetAllCfgStatuses()
        {
            return Context.CfgStatuses.OrderBy(x => x.display_order).ToArray();
        }
        #endregion Cfg

        #region Account
        public Account? GetAccount(int? account_id)
        {
            return Context.Accounts.Find(account_id);
        }

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

        public Account[] GetAllAccounts()
        {
            return Context.Accounts.ToArray();
        }

        public Account UpdateAccount(int account_id, int userId, string first_name, string last_name, string username, string? password_hash, bool is_active, string? phone, string? email)
        {
            Account? entity = Context.Accounts.Find(account_id);

            entity ??= new Account
            {
                created_at = DateTimeOffset.UtcNow,
                created_by = userId,
                first_name = first_name,
                last_name = last_name,
                username = username,
            };

            entity.updated_at = DateTimeOffset.UtcNow;
            entity.updated_by = userId;
            entity.first_name = first_name;
            entity.last_name = last_name;
            entity.username = username;
            if (password_hash != null && password_hash.IsWhiteSpace() == false) entity.password_hash = password_hash;
            entity.is_active = is_active;
            entity.phone = phone;
            entity.email = email;

            if (entity.account_id == 0)
                Context.Accounts.Add(entity);
            else
                Context.Accounts.Update(entity);
            Context.SaveChanges();

            return entity;
        }
        #endregion Account

        #region Vehicle
        public Vehicle? GetVehicle(int? vehicle_id)
        {
            return Context.Vehicles.Find(vehicle_id);
        }

        public List<Vehicle> GetAllVehiclesByAccountId(int? account_id)
        {
            return Context.Vehicles.Where(x => x.account_id == account_id).ToList();
        }
        #endregion Vehicle

        #region WorkOrder
        public WorkOrderView[] GetAllActiveWorkOrders()
        {
            return Context.WorkOrderViews.Where(x => x.status_description != "Completed" && x.status_description != "Canceled").ToArray();
        }

        public WorkOrderView? GetWorkOrderView(int? work_order_id)
        {
            return Context.WorkOrderViews.Find(work_order_id);
        }

        public WorkOrder? GetWorkOrder(int? work_order_id)
        {
            return Context.WorkOrders.Find(work_order_id);
        }

        public WorkOrder UpdateWorkOrder(int work_order_id, int userId, int account_id, int vehicle_id, int cfg_status_id, string? description, string? notes)
        {
            WorkOrder? entity = Context.WorkOrders.Find(work_order_id);

            entity ??= new WorkOrder
            {
                created_at = DateTimeOffset.UtcNow,
                created_by = userId,
                vehicle_id = vehicle_id, // Only set vehicle_id on new work orders. Existing work orders should never override vehicle_id.
            };

            entity.updated_at = DateTimeOffset.UtcNow;
            entity.updated_by = userId;
            entity.account_id = account_id;
            entity.cfg_status_id = cfg_status_id;
            entity.description = description;
            entity.notes = notes;

            if (entity.work_order_id == 0)
                Context.WorkOrders.Add(entity);
            else
                Context.WorkOrders.Update(entity);
            Context.SaveChanges();

            return entity;
        }
        #endregion WorkOrder

    }
}
