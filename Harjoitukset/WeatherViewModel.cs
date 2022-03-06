using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Harjoitukset
{
	public class WeatherViewModel
	{
		// HUOM: tyyppinä on ObservableCollection, joka automaattisesti
		// huolehtii Data Bindingin vaatimasta 
		// PropertyChanged-ominaisuudesta!
		private ObservableCollection<Weather> weathers = new ObservableCollection<Weather>();

		// tehdään myös property ylläolevasta muuttujasta
		public ObservableCollection<Weather> Weathers { get { return this.weathers; } }

		public WeatherViewModel()
		{
			String JSON_URL = "https://edu.frostbit.fi/api/weather/";

			// contents muuttujan sisältö voi tulla tiedostostakin,
			// ks. tiedoston lukeminen, esimerkit Moodlessa
			string contents;
			using (var wc = new System.Net.WebClient())
				contents = wc.DownloadString(JSON_URL);


			// on hyvä idea testata etukäteen vaikka näin että tulihan raaka-JSON perille asti
			//Debug.WriteLine(contents);

			// muutetaan taulukoksi
			JsonArray weatherItems = JsonArray.Parse(contents);

			// lisätään jokainen säätiedotus silmukassa observablecollectioniin
			foreach (JsonValue objvalue in weatherItems)
			{
				JsonObject obj = objvalue.GetObject() as JsonObject;

				this.weathers.Add(new Weather()
				{
					Location = obj.GetNamedString("location"),
					Snow = obj.GetNamedNumber("snow"),
					Rain = obj.GetNamedNumber("rain"),
					Wind = obj.GetNamedNumber("wind")
				});
			}

		}
	}
}
