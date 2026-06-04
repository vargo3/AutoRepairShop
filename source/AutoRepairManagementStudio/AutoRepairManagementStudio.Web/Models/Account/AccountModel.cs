using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagementStudio.Web.Models.Account
{
    /// <summary>
    /// Edit Model for <see cref="AutoRepairManagementStudio.DataAccessLayer.Entities.Account">Account</see>
    /// </summary>
    public class AccountModel
    {

        public int account_id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(64)]
        public string first_name { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MaxLength(64)]
        public string last_name { get; set; } = string.Empty;

        [Display(Name = "Is Active")]
        public bool is_active { get; set; }

        [Display(Name = "User Name")]
        [MaxLength(64)]
        public string username { get; set; } = string.Empty;

        [Display(Name = "Password")]
        [MaxLength(64)]
        public string? password_hash { get; set; } = string.Empty;

        [Display(Name = "Phone")]
        [MaxLength(20)]
        public string? phone { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [MaxLength(64)]
        public string? email { get; set; } = string.Empty;

        public int cfg_user_role_id { get; set; }

    }
}
