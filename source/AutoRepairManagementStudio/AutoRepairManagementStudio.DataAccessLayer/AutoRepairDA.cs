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
        public AppUser? GetAppUserByUsername(string username)
        {
            return Context.AppUsers.FirstOrDefault(u => u.username == username);
        }

        public void AppUserFailedLogin(int userId)
        {
            var user = Context.AppUsers.FirstOrDefault(u => u.app_user_id == userId);
            if (user == null) return;

            user.password_attempt_count += 1;
            if (user.password_attempt_count >= 5) // 5 attempts before lockout. This threshold can be adjusted as needed.
            {
                user.is_locked = true;
                user.locked_at = DateTimeOffset.UtcNow;
            }
            Context.SaveChanges();
        }

        public void AppUserUpdate(int userId)
        {
            var user = Context.AppUsers.FirstOrDefault(u => u.app_user_id == userId);
            if (user != null)
            {
                user.password_attempt_count += 1;
                if (user.password_attempt_count >= 5) // Assuming 5 attempts before lockout
                {
                    user.is_locked = true;
                    user.locked_at = DateTimeOffset.UtcNow;
                }
                Context.SaveChanges();
            }
        }
        #endregion AppUser

        #region CfgSetting

        #endregion CfgSetting
    }
}
