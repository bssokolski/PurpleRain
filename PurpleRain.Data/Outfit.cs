using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Data
{
    public enum TopType { Comfort =1, Tshirt, Sweater, Hoody, Jacket, Coat, Dressshirt, Suit, Dress, Prince}
    public enum BottomType { Sweatpants =1, Shorts, Pants, Mini_Skirt, Midi_Skirt,Maxi_Skirt, Dress, Leggings, Jeans,  }

    public enum Temperature { zero = 0, one, two, three, four, five, six, seven, eight, nine, ten}
    public class Outfit
    {
        [Key]
        public int OutfitID { get; set; }
        [MaxLength(30, ErrorMessage = "Limit characters to 30")]
        public string OutfitName { get; set; }
        public TopType Top { get; set; }
        public BottomType Bottom { get; set; }
        public int? LocationID { get; set; }
        public Temperature OtempRange { get; set; }
    }
}