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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Harjoitukset.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Harjoitus31a : Page, INotifyPropertyChanged
    {
        public Harjoitus31a()
        {
            // Luodaan uusi salasana.
            PassWord = CreateRandomPassword(15);
            UselessFact = GetUselessFact();
            this.InitializeComponent();
        }

        public String PassWord { get; set; }
        public String UselessFact { get; set; }

        private void passwd_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan uusi salasana.
            PassWord = CreateRandomPassword(15);

            // Päivitetään uusi salasana.
            OnPropertyChanged("PassWord");
        }

        private void fact_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan uusi fakta.
            UselessFact = GetUselessFact();

            // Päivitetään uusi fakta.
            OnPropertyChanged("UselessFact");
        }

        // Luo salasanan.
        private string CreateRandomPassword(int length)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        // Hakee netistä turhan faktan.
        private String GetUselessFact()
        {
            String contents;
            String url = "https://uselessfacts.jsph.pl/random.json?language=en";
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(url);

            JsonObject obj = JsonObject.Parse(contents);
            string fact = obj.GetNamedString("text");
            return fact;
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
