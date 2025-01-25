using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareSellingCA.Models
{
    public class UserPasswordHash
    {
        [Required]
        [MaxLength(30)]
        [Column("username")]
        [Key]
        public string Username { get; set; }

        [MaxLength(128)]
        [Column("passwordhashcode")]
        public string PasswordHash { get; set; }
    }
}
