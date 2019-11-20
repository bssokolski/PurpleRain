using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class OutfitListItem
    {
        [Display(Name = "Outfit ID")]
        public int OutfitID { get; set; }
        [Display(Name = "Outfit Name")]
        public string OutfitName { get; set; }
        [Display(Name = "Top")]
        public TopType Top { get; set; }
        [Display(Name = "Bottom")]
        public BottomType Bottom { get; set; }
    }
}
