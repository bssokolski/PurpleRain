using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Data
{
    public enum ActivityType { Biking = 1, Walking, Hiking, Swimming, Sports, Gaming, Movie, Reading, Studying, Skiing, Snowboarding, Surfing, Roleplaying, Dancing }
    public enum Atemperature { Zero = 0, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }
    public class Actionz
    {
        [Key]
        public int ActivityID { get; set; }
        public ActivityType Activity { get; set; }
        public int? LocationID { get; set; }
        public Atemperature AtempRange { get; set; }
    }
}
