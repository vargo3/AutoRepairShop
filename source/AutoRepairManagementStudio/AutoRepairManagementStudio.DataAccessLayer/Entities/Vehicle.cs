using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("vehicle")]
    [Index(nameof(vin), IsUnique = true)]
    [Index(nameof(license_plate), IsUnique = true)]
    public class Vehicle
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vehicle_id { get; set; }

        [Required]
        public DateTimeOffset created_at { get; set; }

        [Required]
        public int created_by { get; set; }

        [Required]
        public DateTimeOffset updated_at { get; set; }

        [Required]
        public int updated_by { get; set; }

        [Required]
        public int account_id { get; set; }

        [Required]
        public int cfg_model_id { get; set; }

        [Required]
        public short year { get; set; }

        [Required]
        [MaxLength(32)]
        public required string color { get; set; }

        [Required]
        [MaxLength(17)]
        [MinLength(17)]
        public required string vin { get; set; }

        [Required]
        [MaxLength(15)]
        public required string license_plate { get; set; }

    }
}
