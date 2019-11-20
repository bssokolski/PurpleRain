using PurpleRain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class ActionCreate
    {
        [Required]
        public ActivityType Activity { get; set; }
    }
}
