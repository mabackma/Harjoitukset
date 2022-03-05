using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitukset
{
	public class Event
	{
		// luokan propertyt (muuttujat)
		public string EvName { get; set; }
		public string EvAddress { get; set; }
		public string EvTime { get; set; }

		public Event()
		{
			// oletusarvot
			this.EvName = "No artist";
			this.EvAddress = "No album";
			this.EvTime = "No date";
		}

		// apuproperty, jonka avulla saadaan yhteenveto levyn tiedoista
		public string OneLineSummary
		{
			get
			{
				return $"{this.EvTime} {this.EvName} - {this.EvAddress}";
			}
		}
	}
}
