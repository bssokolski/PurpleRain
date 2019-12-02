using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class OutfitEdit
    {
        public int OutfitID { get; set; }
        public string OutfitName { get; set; }
        public TopType Top { get; set; }
        public BottomType Bottom { get; set; }

    }
}
