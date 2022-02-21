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

// Rectanglen värin vaihtoon tarvittavia kirjastoja
using Windows.UI;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus15 : Page
    {
        public Harjoitus15()
        {
            this.InitializeComponent();
        }

        private void colorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Tehdään tyyppimuunnos valikolle
            ComboBox cb = (ComboBox)sender;

            // Luodaan ComboboxItem tyyppinen muuttuja valitulle arvoĺle
            ComboBoxItem item = cb.SelectedItem as ComboBoxItem;

            // Haetaan valittu väri String muuttujaan
            String value = item.Content as String;

            colorName.Text = value + ":";

            //Väritetään laatikko valitulla värillä
            switch (value)
            {
                case "Sininen":
                    colorBox.Fill = new SolidColorBrush(Colors.Blue);
                    break;
                case "Vihreä":
                    colorBox.Fill = new SolidColorBrush(Colors.Green);
                    break;
                case "Keltainen":
                    colorBox.Fill = new SolidColorBrush(Colors.Yellow);
                    break;
                case "Oranssi":
                    colorBox.Fill = new SolidColorBrush(Colors.Orange);
                    break;
                case "Punainen":
                    colorBox.Fill = new SolidColorBrush(Colors.Red);
                    break;
            }

        }

    }
}
