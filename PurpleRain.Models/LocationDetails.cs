using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class LocationDetails
    {
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Outfit")]
        public virtual Outfit Outfit { get; set; }
        [Display(Name = "Activity")]
        public Data.Actionz Action { get; set; }   // "Action" is used elsewhere (system.action), Had to Specify it as Action class from data

    }
}
