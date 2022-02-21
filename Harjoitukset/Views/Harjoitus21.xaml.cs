using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class Harjoitus21 : Page
    {
        // Muuttuja joka pitää kirjaa kirjainten määrästä.
        int letters = 0;

        public Harjoitus21()
        {
            this.InitializeComponent();
        }

        private void inputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Tulostetaan montako kirjainta tekstikentässä on.
            letters = inputText.Text.Length;
            displayLetters.Text = letters.ToString();
        }

        private void inputText_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            // Nollataan letters muuttuja ja tyhjennetään tekstikenttä.
            if (e.Key == VirtualKey.Escape)
            {
                letters = 0;
                inputText.Text = "";
            }

            // Tulostetaan montako kirjainta tekstikentässä on.
            displayLetters.Text = letters.ToString();

        }
    }
}
