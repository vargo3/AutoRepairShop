using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("account")]
    [Index(nameof(username), IsUnique = true)]
    [Index(nameof(email), IsUnique = true)]
    public class Account
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int account_id { get; set; }

        [Required]
        public DateTimeOffset created_at { get; set; }

        [Required]
        public int created_by { get; set; }

        [Required]
        public DateTimeOffset updated_at { get; set; }

        [Required]
        public int updated_by { get; set; }

        [Required]
        [MaxLength(64)]
        public required string first_name { get; set; }

        [Required]
        [MaxLength(64)]
        public required string last_name { get; set; }

        [Required]
        public bool is_active { get; set; }

        [Required]
        [MaxLength(64)]
        public required string username { get; set; }

        [MaxLength(64)]
        public string? password_hash { get; set; }

        [Required]
        public int password_attempt_count { get; set; }

        [Required]
        public bool is_locked { get; set; }

        public DateTimeOffset? locked_at { get; set; }

        [MaxLength(20)]
        public string? phone { get; set; }

        [MaxLength(20)]
        public string? email { get; set; }

        [Required]
        public int cfg_user_role_id { get; set; }

    }
}
