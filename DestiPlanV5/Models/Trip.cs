using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestiPlanv5.Models
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string DestinationName { get; set; }
        public int TripLength { get; set; }
        public int Budget { get; set; }
        public string ImageSource { get; set; }
        public string Details { get; set; }

    }
}
