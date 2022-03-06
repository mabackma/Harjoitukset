using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitukset
{
    public class Weather
    {
        public string Location { get; set; }
        public double Snow { get; set; }
        public double Rain { get; set; }
        public double Wind { get; set; }

        public Weather()
        {
            Location = "Ei nimeä";
            Snow = 0.0;
            Rain = 0.0;
            Wind = 0.0;
        }

        public String Summary
        {
            get
            {
                return Location;
            }
        }

    }
}
