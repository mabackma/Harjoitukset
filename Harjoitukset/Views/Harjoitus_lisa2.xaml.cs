using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus_lisa2 : Page
    {
        public Harjoitus_lisa2()
        {
            this.InitializeComponent();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Initialize a new text for message dialog
            string message = "Version 1.0";

            // Initialize a new MessageDialog instance
            MessageDialog messageDialog = new MessageDialog(message, "C#/UWP Tehtävät");

            // Display the message dialog
            _ = messageDialog.ShowAsync();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            // Navigoidaan ensimmäiselle sivulle
            this.Frame.Navigate(typeof(Contents));
        }


        private async void ExitProgram_ClickAsync(object sender, RoutedEventArgs e)
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

        private void DarkMode_Click(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                String currentTheme = frameworkElement.RequestedTheme.ToString();

                // Laitetaan Dark mode päälle tai pois päältä.
                if (currentTheme == "Dark")
                    frameworkElement.RequestedTheme = ElementTheme.Light;
                else
                    frameworkElement.RequestedTheme = ElementTheme.Dark;
            }
        }
    }
}
