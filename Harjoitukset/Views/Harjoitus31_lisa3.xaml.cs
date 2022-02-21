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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus31_lisa3 : Page, INotifyPropertyChanged
    {
        
        public Harjoitus31_lisa3()
        {
            this.InitializeComponent();
            
            // Luetaan tiedosto heti ohjelman käynnistymisen jälkeen.
            _ = ReadFileAsync();
        }


        // TwoWay Binding
        private String txtValue;

        // TwoWay Binding
        public String TextValue
        {
            get
            {
                return txtValue;
            }

            set
            {
                txtValue = value;
                OnPropertyChanged("TextValue");
            }
        }

        private async System.Threading.Tasks.Task ReadFileAsync()
        {
            // haetaan Windowsista kansio, johon tällä ohjelmalla on kirjoitusoikeus
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("usertext.txt");

            // luetaan tiedoston sisältö muuttujaan
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            // tulostetaan myös tiedoston polku että tiedetään mihin se oikeasti tallentui
            Debug.WriteLine(file.Path);
            Debug.WriteLine(text);

            // Annetaan teksti TwoWay Binding muuttujalle.
            TextValue = text;

        }

        private async System.Threading.Tasks.Task WriteFileAsync()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.CreateFileAsync("usertext.txt",
                    Windows.Storage.CreationCollisionOption.OpenIfExists);

            // kirjoitetaan tiedostoon, RatingText on TextBlock XAMLissa
            await Windows.Storage.FileIO.WriteTextAsync(file, text1.Text);

        }

        private void saveText_Click(object sender, RoutedEventArgs e)
        {
            // tallennetaan tiedostoon
            _ = WriteFileAsync();
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
