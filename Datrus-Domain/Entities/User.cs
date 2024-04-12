using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datrus_Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ClientId { get; set; }

        [StringLength(80)]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string ImageSrc { get; set; }

        //non required attributes of a user
        [StringLength(200)]
        [Required]
        public string FirstLanguage { get; set; }

        [StringLength(200)]
        public string Religion { get; set; }

    }
}
