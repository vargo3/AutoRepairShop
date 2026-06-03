using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoRepairManagementStudio.Web.Services
{
    public class AccountService
    {
        public AccountService(AutoRepairContext context)
        {
            DataAccess = new AutoRepairDA(context);
        }

        #region Data Members
        private AutoRepairDA DataAccess { get; }
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

            Account? user = DataAccess.GetAppUserByUsername(model.Username);
            if (user == null)
            {
                return "Username and Password not found.";
            }
            else if (user.password_hash != null && user.password_hash != model.Password)
            {
                if (user != null) DataAccess.AppUserFailedLogin(user.account_id);

                return "Username and Password not found.";
            }
            else if (user.is_active || user.is_locked)
            {
                return "User is locked. Please contact your administrator for support.";
            }
            else if (user.password_hash == null)
            {
                //TODO: prompt user to set password
            }

            return null;
        }

    }
}
