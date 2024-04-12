using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datrus_Domain.Entities
{
    public class UserPreferences
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserPreferenceId { get; set; }

        [ForeignKey("ClientId")]
        public string ClientId { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public int MinAge { get; set; }

        [StringLength(50)]
        public int MaxAge { get; set; }

    }
}
