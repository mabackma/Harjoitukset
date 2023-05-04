using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus34 : Page, INotifyPropertyChanged      // Tämä pitää muistaa bindingissa jonka arvoa käyttäjä voi itse muuttaa!!!
    {
        public Harjoitus34()
        {
            this.InitializeComponent();
        }

        private DateTimeOffset dValue;

        public DateTimeOffset DateValue
        {
            get
            {
                return dValue;
            }

            set
            {
                dValue = value;
                OnPropertyChanged("DateValue");
            }
        }

        // Function Binding metodi joka hakee kuvan DateTimeOffset muuuttujasta.
        public ImageSource ShowImage(DateTimeOffset d)
        {
            // Luodaan tekstimuuttuja kuvan sijainnille.
            String imagePath = "../Assets/";

            // Kuva valitaan kuukauden perusteella.
            if (d.Month > 2 && d.Month <= 5)
                imagePath += "kevat.jpg";
            else if (d.Month > 5 && d.Month <= 8)
                imagePath += "kesa.jpg";
            else if (d.Month > 8 && d.Month <= 11)
                imagePath += "syksy.jpg";
            else
                imagePath += "talvi.jpg";

            // Muutetaan teksti kuvaksi ja palautetaan se image-controliin.
            return StringToImage(imagePath);
        }

        // apumetodi, joka muuttaa tekstin kuvaksi
        // object orig voi olla esim. XAML-Cntrolin Tag-property, 
        // sillä se kääntyy helposti String-muotoon!
        public ImageSource StringToImage(String orig)
        {
            BitmapImage image = new BitmapImage(new Uri(@"ms-appx:///Assets/autumn.jpg"));
            try
            {
                //String path = orig as String;
                image = new BitmapImage(new Uri(@"ms-appx:///Assets/" + orig));
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
