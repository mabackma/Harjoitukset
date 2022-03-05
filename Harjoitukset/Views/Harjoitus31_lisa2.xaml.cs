using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus31_lisa2 : Page, INotifyPropertyChanged
    {
        public Harjoitus31_lisa2()
        {
            this.InitializeComponent();

            // Asetetaan laatikon väri mustaksi.
            ColorValue = initialColor;
        }

        private ComboBoxItem coValue;

        public ComboBoxItem ColorValue
        {
            get
            {
                return coValue;
            }

            set
            {
                coValue = value;
                OnPropertyChanged("ColorValue");
            }
        }

        // apumetodi, joka muuntaa sanan väriksi (brush)
        public SolidColorBrush StringToBrush(object orig)
        {
            SolidColorBrush brush = new SolidColorBrush();
            System.Drawing.Color c = System.Drawing.Color.FromName(orig as String);
            Windows.UI.Color color = Windows.UI.Color.FromArgb(c.A, c.R, c.G, c.B);
            brush = new SolidColorBrush(color);
            return brush;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Metodi Binding päivittämistä varten.
        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
