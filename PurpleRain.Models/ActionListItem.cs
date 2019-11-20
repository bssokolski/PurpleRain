using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
        public class ActionListItem
        {
            [Display(Name = "Action ID")]
            public int ActionID { get; set; }
            [Display(Name = "Outfit Name")]
            public ActivityType ActivityType { get; set; }
        }
}
