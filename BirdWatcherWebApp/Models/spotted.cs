using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdWatcherWebApp.Models
{
    public class spotted
    {
        public int id { get; set; }
        public User Spotter { get; set; }
        public Bird SpottedBird { get; set; }

        public string Bird { get; set; }
        public int QuantitySpotted { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }
        public DateTime DateSpotted { get; }
    }
}
