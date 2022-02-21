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
    public sealed partial class Harjoitus31_lisa1 : Page, INotifyPropertyChanged
    {
        public Harjoitus31_lisa1()
        {
            this.InitializeComponent();
        }

        private ComboBoxItem cValue;
        private object converter;

        public ComboBoxItem ComboValue
        {
            get
            {
                return cValue;
            }

            set
            {
                cValue = value;
                OnPropertyChanged("ComboValue");
            }
        }

        // Function Binding metodi joka muuttaa tekstin kuvaksi.
        public ImageSource ComboValueToSource(object orig)
        {
            // Luodaan tekstimuuttuja kuvan sijainnille.
            String value = orig as String;
            String imagePath = "../Assets/" + value;

            // Muutetaan teksti kuvaksi ja palautetaan se image-controliin.
            return StringToImage(imagePath);
        }

        // apumetodi, joka muuttaa tekstin kuvaksi
        // object orig voi olla esim. XAML-Cntrolin Tag-property, 
        // sillä se kääntyy helposti String-muotoon!
        public ImageSource StringToImage(object orig)
        {
            BitmapImage image = new BitmapImage(new Uri(@"ms-appx:///Assets/autumn.jpg"));
            try
            {
                String path = orig as String;
                image = new BitmapImage(new Uri(@"ms-appx:///Assets/" + path));
            }
            catch (Exception e)
            {
                // tiedostoa ei löytynyt tai muu virhe
                Debug.WriteLine(e.Message);
            }

            return image;
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
