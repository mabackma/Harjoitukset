using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Harjoitukset
{
	public class EventViewModel
	{
		// HUOM: tyyppinä on ObservableCollection, joka automaattisesti
		// huolehtii Data Bindingin vaatimasta 
		// PropertyChanged-ominaisuudesta!
		private ObservableCollection<Event> events = new ObservableCollection<Event>();

		// tehdään myös property ylläolevasta muuttujasta
		public ObservableCollection<Event> Events { get { return this.events; } }

		public EventViewModel()
		{
			// Nettiosoite joka sisältää tapahtumia JSON muodossa.
			string url = "https://edu.frostbit.fi/api/events/";

			// Tehdään string muuttuja.
			string contents;

			// Haetaan nettisoitteesta data string muuttujaan.
			using (var wc = new System.Net.WebClient())
				contents = wc.DownloadString(url);

			// Laitetaan string muuttujasta tapahtumat JsonArray taulukkoon.
			JsonArray eventItems = JsonArray.Parse(contents);

			foreach (JsonValue objvalue in eventItems)
			{
				// Tehdään jokaisesta JsonValuesta JsonObject muuttuja.
				JsonObject obj = objvalue.GetObject() as JsonObject;

				// Tehdään JsonObject muuttuja myös osoitteesta koska osoite on itsessään myös muotoa JsonValue
				JsonValue addressValue = obj.GetNamedValue("address");
				JsonObject addressObj = addressValue.GetObject() as JsonObject;

				// Tuodaan JsonObjektista kategoria tiedot string muuttujaan.
				string categories = obj.GetNamedValue("categories").ToString();

				// Siistitään kategoria muuttujasta ylimääräiset merkit pois.
				categories = categories.Replace("\"", string.Empty);
				categories = categories.Replace("[", string.Empty);
				categories = categories.Replace("]", string.Empty);
				categories = categories.Replace(",", ", ");

				// Siistitään tapahtuman tiedot ja sijoitetaan ne string muuttujiin
				string name = obj.GetNamedValue("name").ToString().Replace("\"", string.Empty);
				string street = addressObj.GetNamedValue("street_address").ToString().Replace("\"", string.Empty);
				string postal = addressObj.GetNamedValue("postal_code").ToString().Replace("\"", string.Empty);
				string time = obj.GetNamedValue("date").ToString().Replace("\"", string.Empty);

				// Lisätään kaikki muuttujat tapahtuman tietoihin ja lisätään tapahtuma events kokoelmaan.
				this.events.Add(new Event()
				{
					EvName = name,
					EvAddress = street + ", " + postal,
					EvTime = time,
					EvCategories = "Kategoriat: " + categories
				});

			}
		}

	}
}
