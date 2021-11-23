using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class EmployeeGroupAssoc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "CreatedBy must be between 1 and 50 characters")]
        public string CreatedBy { get; set; }

        public DateTime LastModifiedUtcDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "LastModifiedBy must be between 1 and 50 characters")]
        public string LastModifiedBy { get; set; }
    }
}