using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareSellingCA.Models
{
    public class ActivationCodeProductCustomer
    {
        [Required]
        [Key]
        public string ActivateCode { get; set; }

        public long PurchaseDateUnix { get; set; }

        [Required]
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        [Required]
        [ForeignKey("CustomerDetails")]
        public string CustomerDetailsId { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual CustomerDetails CustomerDetails { get; set; }

        public ActivationCodeProductCustomer()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            PurchaseDateUnix = dateTimeOffset.ToUnixTimeSeconds();
            ActivateCode = Guid.NewGuid().ToString();
        }
    }
}
