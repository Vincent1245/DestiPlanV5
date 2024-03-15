using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestiPlanv5.Models
{
    internal class Ticket
    {
        public int NoOfPeople { get; set; }
        public string DepartureLocationCode { get; set; }
        public string ArrivalLocationCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double PriceTotal { get; set; }
        public string CarrierCode { get; set; }

    }
}
