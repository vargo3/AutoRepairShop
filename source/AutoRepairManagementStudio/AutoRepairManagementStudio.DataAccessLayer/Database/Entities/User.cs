using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagementStudio.DataAccessLayer.Database.Entities
{
    public class App_User
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
