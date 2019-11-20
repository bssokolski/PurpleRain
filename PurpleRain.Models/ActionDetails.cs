using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class ActionDetails
    {
        [Display(Name = "Action ID")]
        public int ActivityID { get; set; }
        [Display(Name = "Activity")]
        public ActivityType Activity { get; set; }
    }
}
