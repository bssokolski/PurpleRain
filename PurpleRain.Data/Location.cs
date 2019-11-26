using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Data
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [MaxLength(30, ErrorMessage = "Limit characters to 30")]
        public string LocationName { get; set; }
        [MaxLength(30, ErrorMessage = "Limit characters to 30")]
        public string CityName { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [ForeignKey("Outfit")]
        public int? OutfitID { get; set; }
        [ForeignKey("Action")]
        public int? ActivityID { get; set; }
        public virtual Action Action { get; set; }
        public virtual Outfit Outfit { get; set; }
    }
}
