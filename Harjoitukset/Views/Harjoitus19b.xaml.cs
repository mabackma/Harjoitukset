using System;
using System.Collections.Generic;
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
    public sealed partial class Harjoitus19b : Page
    {
        // Julkiset muuttujat päivämäärälle ja ajalle.
        public String d = "";
        public String t = "";
        public Harjoitus19b()
        {
            this.InitializeComponent();
        }

        private void pickDate_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            // Annetaan päivämäärä String muodossa päivämäärämuuttujaan.
            DateTime selectedDate = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            d = selectedDate.Day.ToString() + "/" + selectedDate.Month.ToString() + "/" + selectedDate.Year.ToString() + " ";

            // Tulostetaan päivämäärä ja aika tekstikenttään.
            dateAndTime.Text = d + t;
        }

        private void pickTime_SelectedTimeChanged(TimePicker sender, TimePickerSelectedValueChangedEventArgs args)
        {
            // Annetaan aika String muodossa aikamuuttujaan.
            TimeSpan selectedTime = new TimeSpan(args.NewTime.Value.Hours, args.NewTime.Value.Minutes, args.NewTime.Value.Seconds);
            t = selectedTime.Hours.ToString() + ":" + selectedTime.Minutes.ToString();

            // Tulostetaan päivämäärä ja aika tekstikenttään.
            dateAndTime.Text = d + t;
        }
    }
}
