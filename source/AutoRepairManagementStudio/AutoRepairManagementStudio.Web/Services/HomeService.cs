using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;
using AutoRepairManagementStudio.Web.Models;
using AutoRepairManagementStudio.Web.Models.Account;
using AutoRepairManagementStudio.Web.Models.Home;
using AutoRepairManagementStudio.Web.Models.WorkOrder;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairManagementStudio.Web.Services
{
    public class HomeService
    {
        public HomeService(AutoRepairContext context)
        {
            DataAccess = new AutoRepairDA(context);
        }

        #region Data Members
        private AutoRepairDA DataAccess { get; }
        #endregion Data Members


        public WorkOrderGridModel GetWorkOrders()
        {
            WorkOrderGridModel model = new WorkOrderGridModel();

            model.WorkOrders = DataAccess.GetAllActiveWorkOrders();

            return model;
        }

        public AccountGridModel GetAccounts()
        {
            AccountGridModel model = new AccountGridModel();

            Account[] accountEntities = DataAccess.GetAllAccounts();

            model.Accounts = new AccountModel[accountEntities.Length];
            for(int i = 0; i < accountEntities.Length; i++)
            {
                Account account = accountEntities[i];
                model.Accounts[i] = new AccountModel
                {
                    account_id = account.account_id,
                    first_name = account.first_name,
                    last_name = account.last_name,
                    is_active = account.is_active,
                    username = account.username,
                    password_hash = account.password_hash,
                    phone = account.phone,
                    email = account.email,
                    cfg_user_role_id = account.cfg_user_role_id
                };
            }

            return model;
        }

    }
}
