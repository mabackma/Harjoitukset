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
    public sealed partial class Harjoitus22 : Page
    {
        public Harjoitus22()
        {
            this.InitializeComponent();
        }

        private void box1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Muutetaan toisen laatikon väri violetiksi.
            box2.Fill = new SolidColorBrush(Colors.Violet);
        }

        private void box1_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Muutetaan toisen laatikon väri takaisin oranssiksi.
            box2.Fill = new SolidColorBrush(Colors.Orange);
        }
    }
}
