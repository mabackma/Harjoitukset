using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus31b : Page, INotifyPropertyChanged
    {

        public Harjoitus31b()
        {
            this.InitializeComponent();
        }

        private double s1Value;
        public double Slider1Value
        {
            get
            {
                return s1Value;
            }

            set
            {
                s1Value = value;
                OnPropertyChanged("Slider1Value");
            }
        }

        // Function Binding metodi joka muuttaa double arvon String arvoksi.
        public String Slider1ValueToString(double val)
        {
            String result = val.ToString();
            return result;
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

