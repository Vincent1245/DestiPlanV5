using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestiPlanv5.Models
{
    public class ConvertCurrency
    { 
        public double new_amount { get; set; }
        public string new_currency { get; set; }
        public string old_currency { get; set; }
        public double old_amount { get; set; }
    }


}
