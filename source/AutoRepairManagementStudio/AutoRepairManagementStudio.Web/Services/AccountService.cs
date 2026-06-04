using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.Web.Models.Account;
using AutoRepairManagementStudio.Web.Models.WorkOrder;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoRepairManagementStudio.Web.Services
{
    public class AccountService
    {
        public AccountService(AutoRepairContext context, int? userId)
        {
            DataAccess = new AutoRepairDA(context);
            this.userId = userId;
        }

        #region Data Members
        private AutoRepairDA DataAccess { get; }
        private int? userId { get; }
        #endregion Data Members


        /// <summary>
        /// Validates the user login credentials and returns an error message if the login fails. If the login is successful, it returns null.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>error message if the login fails or null</returns>
        public string? ValidateLogin(LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return "Username and password are required.";
            }

            Account? user = DataAccess.GetAccountByUsername(model.Username);
            if (user == null)
            {
                return "Username and Password not found.";
            }
            else if (user.password_hash != null && user.password_hash != model.Password)
            {
                if (user != null) DataAccess.AccountFailedLogin(user.account_id);

                return "Username and Password not found.";
            }
            else if (user.is_active == false || user.is_locked)
            {
                return "User is locked. Please contact your administrator for support.";
            }
            else if (user.password_hash == null)
            {
                //TODO: prompt user to set password
            }

            return null;
        }

        public AccountModel GetAccount(int? id)
        {
            AccountModel model = new AccountModel();

            Account? entity = DataAccess.GetAccount(id);

            if (entity != null)
            {
                model.account_id = entity.account_id;
                model.first_name = entity.first_name;
                model.last_name = entity.last_name;
                model.is_active = entity.is_active;
                model.username = entity.username;
                model.phone = entity.phone;
                model.email = entity.email;
                model.cfg_user_role_id = entity.cfg_user_role_id;
            }

            return model;
        }

        public int SaveProfile(AccountModel model)
        {
            if (userId == null) throw new Exception("userId is null");

            Account order = DataAccess.UpdateAccount(model.account_id, userId.Value, model.first_name, model.last_name, model.username, model.password_hash, model.is_active, model.phone, model.email);
            return order.account_id;
        }

    }
}
