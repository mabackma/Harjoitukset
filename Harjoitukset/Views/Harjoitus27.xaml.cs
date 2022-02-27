using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class Harjoitus27 : Page
    {
        public Harjoitus27()
        {
            this.InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                String current = frameworkElement.RequestedTheme.ToString();

                if (current == "Dark")
                    frameworkElement.RequestedTheme = ElementTheme.Light;
                else    
                    frameworkElement.RequestedTheme = ElementTheme.Dark;
            }
        }
    }
}
