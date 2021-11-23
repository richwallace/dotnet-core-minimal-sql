using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeGroupAssocs = new HashSet<EmployeeGroupAssoc>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name must be provided")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "FirstName must be between 1 and 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name must be provided")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "LastName must be between 1 and 100 characters")]
        public string LastName { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "DisplayName must be between 1 and 200 characters")]
        public string DisplayName { get; set; }

        public Guid ActiveDirectoryId { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Job Title must not have more than 50 characters")]
        public string JobTitle { get; set; }

        public string EmployeeNumber { get; set; }

        [StringLength(50, ErrorMessage = "MailNickName must not have more than 50 characters")]
        public string MailNickname { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "PhoneNumber must be between 1 and 15 characters")]
        public string BusinessPhone { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "PhoneNumber must be between 1 and 15 characters")]
        public string MobilePhone { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Email must be between 1 and 250 characters")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "CreatedBy must be between 1 and 50 characters")]
        public string CreatedBy { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "LastModifiedBy must be between 1 and 50 characters")]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedUtcDate { get; set; }

        public virtual ICollection<EmployeeGroupAssoc> EmployeeGroupAssocs { get; set; }
    }
}
