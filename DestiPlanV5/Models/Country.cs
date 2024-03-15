using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestiPlanv5.Models
{
    public class Country
    {
        public string name { get; set; }
        public string capital { get; set; }
        public double population { get; set; }
        public double life_expectancy_male { get; set; }
        public double life_expectancy_female { get; set; }
        public Currency currency { get; set; }
        public double internet_users { get; set; }
        public double unemployment { get; set; }

    }

    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
    }

}
