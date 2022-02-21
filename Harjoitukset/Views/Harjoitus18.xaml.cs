using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Harjoitus18 : Page
    {
        public Harjoitus18()
        {
            this.InitializeComponent();
        }

        private void doCalculation(object sender, RoutedEventArgs e)
        {
            double result = 0;
            String strResult = "";

            // Tehdään tyyppimuunnos tekstikentän numeroille double muotoon.
            double x = Convert.ToDouble(number1.Text);
            double y = Convert.ToDouble(number2.Text);

            // Luodaan ComboboxItem tyyppinen muuttuja valitulle arvoĺle.
            ComboBoxItem item = operation.SelectedItem as ComboBoxItem;

            // Haetaan valittu väri String muuttujaan.
            String value = item.Content as String;

            // Suoritetaan laskutoimitus.
            switch (value)
            {
                case "Summa":
                    result = x + y;
                    strResult = result.ToString();
                    break;
                case "Vähennys":
                    result = x - y;
                    strResult = result.ToString();
                    break;
                case "Kertolasku":
                    result = x * y;
                    strResult = result.ToString();
                    break;
                case "Jakolasku":
                    if (y == 0)
                        strResult = "Nollalla ei voi jakaa!";
                    else
                    {
                        result = x / y;
                        strResult = result.ToString();
                    }
                    break;
            }

            // Tulostetaan summa.
            resultBox.Text = strResult;
        }
    }
}
