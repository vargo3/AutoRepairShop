using AutoRepairManagementStudio.Web.Models.Account;

namespace AutoRepairManagementStudio.Web.Models.Home
{
    public class AccountGridModel
    {
        public AccountModel[] Accounts { get; set; } = Array.Empty<AccountModel>();
    }
}
