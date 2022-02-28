using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Harjoitus28 : Page
    {

        public Harjoitus28()
        {
            this.InitializeComponent();
        }

        private async void closeApp_Click(object sender, RoutedEventArgs e)
        {            
            // Luodaan ikkuna ja lisätään sinne vaihtoehdot kyllä ja ei.
            MessageDialog md = new MessageDialog("Haluatko sammuttaa ohjelman?");
            md.Commands.Add(new UICommand("Kyllä"));
            md.Commands.Add(new UICommand("En"));

            // Näytetään ikkuna.
            var confirmResult = await md.ShowAsync();

            // Suljetaan ohjelma kun painetaan Kyllä nappia.
            if (confirmResult.Label == "Kyllä")
                System.Environment.Exit(0); 
            else
                return;
        }
        
    }
}
