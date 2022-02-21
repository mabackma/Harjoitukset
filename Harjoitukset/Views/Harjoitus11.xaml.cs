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
    public sealed partial class Harjoitus11 : Page
    {
        public Harjoitus11()
        {
            this.InitializeComponent();
        }

        private void addNumbers(object sender, RoutedEventArgs e)
        {
            // Tehdään tyyppimuunnos tekstikentän numeroille double muotoon.
            double x = Convert.ToDouble(number1.Text);
            double y = Convert.ToDouble(number2.Text);

            // Lasketaan yhteen numerot.
            double sum = x + y;

            // Muutetaan summa String tyyppiseksi.
            String strSum = sum.ToString();

            // Tulostetaan summa.
            sumBox.Text = strSum;
        }
    }
}
