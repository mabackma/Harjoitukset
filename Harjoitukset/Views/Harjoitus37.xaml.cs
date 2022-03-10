using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
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
    public class Person
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string bYear { get; set; }
        public int workType { get; set; }
        public string salary { get; set; }
        public bool partTimeValue { get; set; }
        public bool activeValue { get; set; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
        public sealed partial class Harjoitus37 : Page, INotifyPropertyChanged
    {

        public Harjoitus37()
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
 
        public Person createObject()
        {

            var obj = new Person
            {
                fName = firstNameDetails.Text,
                lName = lastNameDetails.Text,
                bYear = birthYearDetails.Text,
                workType = positionDetails.SelectedIndex,
                salary = salaryDetails.Text,
                partTimeValue = (bool)isPartTime.IsChecked,
                activeValue = (bool)isActiveDetails.IsChecked
            };

            return obj;

        }

        // Palauttaa JSON stringistä etunimen
        public string GetFNameFromJson(string txt)
        {
            if (txt == null)
                return "";
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.fName;
        }

        // Palauttaa JSON stringistä sukunimen
        public string GetLNameFromJson(string txt)
        {
            if (txt == null)
                return "";
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.lName;
        }

        // Palauttaa JSON stringistä syntymävuoden
        public string GetBYearFromJson(string txt)
        {
            if (txt == null)
                return "";
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.bYear;
        }

        // Palauttaa työntekijän indexin (harjoittelija: 0, työntekijä: 1, esimies: 2)
        public int GetWorkTypeFromJson(string txt)
        {
            if (txt == null)
                return 0;
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.workType;
        }

        // Palauttaa JSON stringistä kuukausipalkan
        public string GetSalaryFromJson(string txt)
        {
            if (txt == null)
                return "";
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.salary;
        }

        // Palauttaa True jos työntekijä on osa-aikainen.
        public bool GetPartTimeFromJson(string txt)
        {
            if (txt == null)
                return false;
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.partTimeValue;
        }

        // Palauttaa False jos työntekijä on osa-aikainen.
        public bool GetNotPartTimeFromJson(string txt)
        {
            if (txt == null)
                return false;
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return !person.partTimeValue;
        }

        // Palauttaa True jos työntekijä on aktiivinen.
        public bool GetActiveFromJson(string txt)
        {
            if (txt == null)
                return false;
            Person person = JsonSerializer.Deserialize<Person>(txt);
            return person.activeValue;
        }
        private async System.Threading.Tasks.Task ReadFileAsync()
        {
            // haetaan Windowsista kansio, johon tällä ohjelmalla on kirjoitusoikeus
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("userinfo.json");

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
            Windows.Storage.StorageFile file = await storageFolder.CreateFileAsync("userinfo.json",
                    Windows.Storage.CreationCollisionOption.OpenIfExists);

            Person p = new Person();
            p = createObject();

            // Muutetaan objektista tekstimuotoon ja kirjoitetaan tiedot tiedostoon.
            string dataText = JsonSerializer.Serialize(p);
            await Windows.Storage.FileIO.WriteTextAsync(file, dataText);

        }
        private void saveJson_Click(object sender, RoutedEventArgs e)
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
