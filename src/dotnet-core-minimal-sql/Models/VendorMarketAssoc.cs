using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class VendorMarketAssoc 
    {
        [Required]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [Required]
        public int MarketId { get; set; }
    }
}