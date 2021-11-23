using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class VendorFinancialVendorAssoc 
    {
        [Required]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [Required]
        public int FinancialVendorId { get; set; }
        public virtual FinancialVendor FinancialVendor { get; set; }
    }
}
