using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Domain.Entities
{
    public class UsersMatch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MatchId { get; set; }

        [ForeignKey("ClientId")]
        public string UserA { get; set; }

        [ForeignKey("ClientId")]
        public string UserB { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}
