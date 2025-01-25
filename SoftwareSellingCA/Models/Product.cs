using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareSellingCA.Models
{
    public class Product
    {
        [Required]
        [MaxLength(20)]
        [Column("productId")]
        [Key]
        public string ProductId { get; set; }

        [MaxLength(50)]
        [Column("name")]
        public string ProductName { get; set; }

        [MaxLength(800)]
        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Required]
        [Column("photoPath")]
        public string PhotoPath { get; set; }

        public virtual ICollection<ActivationCodeProductCustomer> ActivationCodes { get; set; }
    }
}
