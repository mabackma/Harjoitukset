using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Harjoitus210 : Page
    {
        public Harjoitus210()
        {
            this.InitializeComponent();
        }

        private void myPanel_DragOver(object sender, DragEventArgs e)
        {
            // Sallii raahattavan kuvan kopioimisen.
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        // Ajetaan kun kuva tiputetaan kohteeseen.
        private async void myPanel_Drop(object sender, DragEventArgs e)
        {
            // Ohjelman sisältä raahattavan kuvatiedoston tapauksessa:
            // Annetaan kohteelle raahattavan kuvan Source, eli kuvatiedoston polku.
            destination1.Source = sourceImage.Source;

            // Ohjelman ulkopuolelta raahattavan kuvatiedoston tapauksessa:
            // Jos raahattava tapahtuma sisältää jotain järkevää dataa...
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                //... niin haetaan data Images muuttujaan
                var images = await e.DataView.GetStorageItemsAsync();
                
                if (images.Any())
                {
                    // Tehdään BitmapImage datasta ja sijoitetaan se kohteeseen.
                    var storageFile = images.First() as StorageFile;
                    var bmi = new BitmapImage();
                    bmi.SetSource(await storageFile.OpenAsync(FileAccessMode.Read));
                    destination2.Source = bmi;
                }
            }
        }
    }
}
