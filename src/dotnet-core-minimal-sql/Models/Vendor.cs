using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Vendor
    {
        public Vendor()
        {
            VendorFinancialVendorAssocs = new HashSet<VendorFinancialVendorAssoc>();
            VendorMarketAssocs = new HashSet<VendorMarketAssoc>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DoingBusinessAs { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedUtcDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedUtcDate { get; set; }

        public virtual ICollection<VendorFinancialVendorAssoc> VendorFinancialVendorAssocs { get; set; }
        public virtual ICollection<VendorMarketAssoc> VendorMarketAssocs { get; set; }
    }
}