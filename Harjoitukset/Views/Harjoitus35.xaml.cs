using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus35 : Page
    {
        public Harjoitus35()
        {
            this.InitializeComponent();
        }

        private void showDetails_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://restcountries.com/v2/name/";           
            url += countryInput.Text;

            // String muuttuja dataa varten.
            string contents = "";

            try
            {
                // Haetaan nettisoitteesta data string muuttujaan.
                using (var wc = new System.Net.WebClient())
                    contents = wc.DownloadString(url);

                // Laitetaan string muuttujasta tapahtumat JsonArray taulukkoon.
                JsonArray countryDetails = JsonArray.Parse(contents);

                // Tehdään ensimmäisestä JsonValuesta JsonObject muuttuja (JsonArray countryDetails sisältää vain yhden alkion).
                JsonValue objvalue = (JsonValue)countryDetails[0];
                JsonObject obj = objvalue.GetObject() as JsonObject;

                // Haetaan maa-, väkiluku- ja puhelin muuttujille tiedot JsonObjectista.
                string country = obj.GetNamedString("name");
                string population = obj.GetNamedValue("population").ToString();
                string phone = "+" + obj.GetNamedValue("callingCodes").ToString();

                // Siistitään puhelinnumeroa.
                phone = phone.Replace("[", "");
                phone = phone.Replace("]", "");
                phone = phone.Replace("\"", "");

                // Tehdään currencies arvosta JsonArray.
                string currencyContents = obj.GetNamedValue("currencies").ToString();
                JsonArray currencyDetails = JsonArray.Parse(currencyContents);

                // JsonArray currencyDetails sisältää vain yhden alkion.
                JsonValue currencyObjvalue = (JsonValue)currencyDetails[0];
                JsonObject currencyObj = currencyObjvalue.GetObject() as JsonObject;

                // Haetaan valuuttamuutujalle arvo JsonObjectista.
                string currency = currencyObj.GetNamedString("name") + " (" + currencyObj.GetNamedString("symbol") + ")";

                // Tulostetaan tiedot tekstikenttiin.
                details1.Text = country;
                details2.Text = population;
                details3.Text = phone;
                details4.Text = currency;
            }
            catch (WebException)
            {
                // Tyhjennetään tekstikentät.
                details1.Text = "";
                details2.Text = "";
                details3.Text = "";
                details4.Text = "";
            }

        }
    }
}
