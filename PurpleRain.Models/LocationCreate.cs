using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Models
{
    public class LocationCreate
    {
        [Required]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field")]
        public string LocationName { get; set; }

        [MinLength(5, ErrorMessage = "Common 5 digit Zip Code")]
        [MaxLength(5, ErrorMessage = "Common 5 digit Zip Code")]
        [Required]
        public int ZipCode { get; set; }
    }
}
