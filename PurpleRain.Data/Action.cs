using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Data
{
    public enum ActivityType { Biking = 1, Walking, Hiking, Swimming, Sports, Gaming, Movie, Reading, Studying, Skiing, Snowboarding, Surfing, Roleplaying, Dancing,  }
    public enum Atemperature { zero = 0, one, two, three, four, five, six, seven, eight, nine, ten }
    public class Actionz
    {
        [Key]
        public int ActivityID { get; set; }
        public ActivityType Activity { get; set; }
        public Atemperature AtempRange { get; set; }
    }
}
