using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datrus_Domain.Entities
{
    public class LikesSent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LikesSentId { get; set; }

        [ForeignKey("ClientId")]
        public string FromClientId { get; set; }

        [ForeignKey("ClientId")]
        public string ToClientId { get; set; }

        [Required]
        public string LikeType { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}
