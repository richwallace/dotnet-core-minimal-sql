using API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? Prefix { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Suffix { get; set; }
        public string? DisplayName { get; set; }
        public string? MailNickname { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? City1 { get; set; }
        public string? City2 { get; set; }
        public string? City3 { get; set; }
        public string? StateProvince1 { get; set; }
        public string? StateProvince2 { get; set; }
        public string? StateProvince3 { get; set; }
        public string? PostalCode1 { get; set; }
        public string? PostalCode2 { get; set; }
        public string? PostalCode3 { get; set; }
        public string? Country1 { get; set; }
        public string? Country2 { get; set; }
        public string? Country3 { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public string? PhoneExt1 { get; set; }
        public string? PhoneExt2 { get; set; }
        public string? PhoneExt3 { get; set; }
        public string? EmailAddress1 { get; set; }
        public string? EmailAddress2 { get; set; }
        public PreferredCommMethodEnum? PreferredCommunicationMethod { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedUtcDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedUtcDate { get; set; }
    }
}