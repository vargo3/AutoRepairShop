using AutoRepairManagementStudio.DataAccessLayer.Entities;
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

        #region AppUser
        public Account? GetAppUserByUsername(string username)
        {
            return Context.AppUsers.FirstOrDefault(u => u.username == username);
        }

        public void AppUserFailedLogin(int userId)
        {
            Account? user = Context.AppUsers.FirstOrDefault(u => u.account_id == userId);
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

        //public void AppUserUpdate(int userId)
        //{
        //    AppUser? user = Context.AppUsers.FirstOrDefault(u => u.account_id == userId);
        //    if (user == null) return;
        //    Context.SaveChanges();
        //}
        #endregion AppUser

        #region CfgSetting

        #endregion CfgSetting
    }
}
