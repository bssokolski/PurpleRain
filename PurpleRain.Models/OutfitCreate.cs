using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class OutfitCreate
    {
        [MaxLength(30, ErrorMessage = "There are too many characters in this field")]
        public string OutfitName { get; set; }
        [Required]
        public TopType Top { get; set; }
        public BottomType Bottom { get; set; }
    }
}
