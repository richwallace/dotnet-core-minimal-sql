using API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class FinancialVendor
    {
        public FinancialVendor()
        {
            VendorFinancialVendorAssocs = new HashSet<VendorFinancialVendorAssoc>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string Number { get; set; }
        public int MarketId { get; set; }
        public string TaxId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool RequireInvoiceNumber { get; set; }
        public FinancialVendorStatusEnum Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedUtcDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedUtcDate { get; set; }

        public virtual ICollection<VendorFinancialVendorAssoc> VendorFinancialVendorAssocs { get; set; }
    }
}