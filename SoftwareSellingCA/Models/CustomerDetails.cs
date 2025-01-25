using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareSellingCA.Models
{
    public class CustomerDetails
    {
        [Key]
        [Required]
        public string customerid { get; set; }

        public string customername { get; set; }

        public virtual ICollection<ActivationCodeProductCustomer> ActivationCodes { get; set; }
    }
}
