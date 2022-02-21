using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Harjoitus17 : Page
    {
        public Harjoitus17()
        {
            this.InitializeComponent();
        }

        private void randomButton_Click(object sender, RoutedEventArgs e)
        {

            // Luodaan numero välillä 1-20
            Random rnd = new Random();
            int value = rnd.Next(1, 21);

            // Väritetään laatikko.
            if (value < 10)
                colorBox.Fill = new SolidColorBrush(Colors.Blue);
            if (value > 10)
                colorBox.Fill = new SolidColorBrush(Colors.Red);
            if (value == 10)
                colorBox.Fill = new SolidColorBrush(Colors.Yellow);

        }
    }
}
