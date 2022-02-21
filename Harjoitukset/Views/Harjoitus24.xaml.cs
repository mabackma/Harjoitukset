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
    public sealed partial class Harjoitus24 : Page
    {

        // Muuttujat käyttäjän valinnoille.
        Boolean younger_than_18 = false;
        Boolean over_18 = false;
        Boolean over_30 = false;
        Boolean drive = false;
        Boolean safety = false;
        Boolean hygiene = false;

        String info = "";

        public Harjoitus24()
        {
            this.InitializeComponent();
        }

        // Jokaisen eventin lopussa kutsutaan metodia joka tulostaa tiedot tekstikenttään.
        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            younger_than_18 = true;
            showInfo();
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            over_18 = true;
            showInfo();
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            over_30 = true;
            showInfo();
        }

        private void RadioButton1_Unchecked(object sender, RoutedEventArgs e)
        {
            younger_than_18 = false;
            showInfo();
        }

        private void RadioButton2_Unchecked(object sender, RoutedEventArgs e)
        {
            over_18 = false;
            showInfo();
        }

        private void RadioButton3_Unchecked(object sender, RoutedEventArgs e)
        {
            over_30 = false;
            showInfo();
        }
        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            drive = true;
            showInfo();
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            safety = true;
            showInfo();
        }

        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            hygiene = true;
            showInfo();
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            drive = false;
            showInfo();
        }
        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            safety = false;
            showInfo();
        }
        private void CheckBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            hygiene = false;
            showInfo();
        }


        private void showInfo()
        {
            String info = "";

            // Lisätään tekstiin käyttäjän valitsemat tiedot.
            if (younger_than_18)
                info += "alle 18, ";
            if (over_18)
                info += "18-29v, ";
            if (over_30)
                info += "30v+, ";
            if (drive)
                info += "Ajokortti, \n";
            if (safety)
                info += "Työturvallisuuskortti, \n";
            if (hygiene)
                info += "Hygieniapassi";

            // Tulostetaan teksti.
            ShowInfo.Text = info;
        }

    }
}
