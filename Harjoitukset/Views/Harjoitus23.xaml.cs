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
    public sealed partial class Harjoitus23 : Page
    {

        // Muuttujat joita voidaan käsitellä molemmissa SelectionChanged eventeissä.
        String value1 = "0";
        String value2 = "0";

        public Harjoitus23()
        {
            this.InitializeComponent();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Tehdään tyyppimuunnos
            ListBoxItem listItem = list.SelectedItem as ListBoxItem;
            value1 = listItem.Content.ToString();

            // Tulostetaan ListBoxista valitun numeron arvo.
            listValue.Text = value1;

            // Tulostetaan valittujen lukujen summa.
            int total = Convert.ToInt32(value1) + Convert.ToInt32(value2);
            totalValue.Text = total.ToString();
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Tehdään tyyppimuunnos
            ComboBoxItem comboItem = combo.SelectedItem as ComboBoxItem;
            value2 = comboItem.Content.ToString();

            // Tulostetaan comboBoxista valitun numeron arvo.
            comboValue.Text = value2;

            // Tulostetaan valittujen lukujen summa.
            int total = Convert.ToInt32(value1) + Convert.ToInt32(value2);
            totalValue.Text = total.ToString();
        }

    }
}
