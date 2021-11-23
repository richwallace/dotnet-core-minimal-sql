using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "DisplayName must be between 1 and 200 characters")]
        public string DisplayName { get; set; }

        [StringLength(4000, ErrorMessage = "Description can not exceed 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ADIntegrationKey must be provided")]
        public Guid ADIntegrationKey { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "CreatedBy must be between 1 and 50 characters")]
        public string CreatedBy { get; set; }

        public DateTime LastModifiedUtcDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "LastModifiedBy must be between 1 and 50 characters")]
        public string LastModifiedBy { get; set; }

        public virtual ICollection<EmployeeGroupAssoc> EmployeeGroupAssocs { get; set; }
    }
}