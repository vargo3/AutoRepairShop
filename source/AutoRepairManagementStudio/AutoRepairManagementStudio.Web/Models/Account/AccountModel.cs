using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagementStudio.Web.Models.Account
{
    public class AccountModel
    {

        [Display(Name = "User Name")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

    }
}
