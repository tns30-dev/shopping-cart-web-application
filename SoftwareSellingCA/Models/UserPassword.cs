using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftwareSellingCA.Models
{
    public class UserPassword
    {
        [Column("username")]
        [Key]
        public string Username { get; set; }

        [Column("realpassword")]
        public string Password { get; set; }

    }
}
