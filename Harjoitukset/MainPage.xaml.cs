using Harjoitukset.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Harjoitukset
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			// Avataan ohjelman ensimmäinen sivu
			if (!NavigateToView("Contents")) return;
		}
		// Näyttää ohjelman tiedot
		private void About_Click(object sender, RoutedEventArgs e)
		{
			// Initialize a new text for message dialog
			string message = "Version 1.0 Copyright Lapin AMK";

			// Initialize a new MessageDialog instance
			MessageDialog messageDialog = new MessageDialog(message, "C#/UWP Tehtävät");

			// Display the message dialog
			_ = messageDialog.ShowAsync();
		}

		private void GoHome_Click(object sender, RoutedEventArgs e)
		{
			// Avataan ohjelman ensimmäinen sivu
			if (!NavigateToView("Contents")) return;
		}

		// Sulkee ohjelman
		private async void ExitProgram_ClickAsync(object sender, RoutedEventArgs e)
		{
			// Luodaan ikkuna ja lisätään sinne vaihtoehdot kyllä ja ei.
			MessageDialog md = new MessageDialog("Haluatko sammuttaa ohjelman?");
			md.Commands.Add(new UICommand("Kyllä"));
			md.Commands.Add(new UICommand("En"));

			// Näytetään ikkuna.
			var confirmResult = await md.ShowAsync();

			// Suljetaan ohjelma kun painetaan Kyllä nappia.
			if (confirmResult.Label == "Kyllä")
				System.Environment.Exit(0);
			else
				return;
		}

		private void DarkMode_Click(object sender, RoutedEventArgs e)
		{
			if (Window.Current.Content is FrameworkElement frameworkElement)
			{
				String currentTheme = frameworkElement.RequestedTheme.ToString();

				// Laitetaan Dark mode päälle tai pois päältä.
				if (currentTheme == "Dark")
					frameworkElement.RequestedTheme = ElementTheme.Light;
				else
					frameworkElement.RequestedTheme = ElementTheme.Dark;
			}
		}
		// tämä pitää kirjaa siitä mitä sivua viimeksi käytettiin
		// tätä hyödynnetään lähinnä siinä, että jos yritetään kaksi
		// kertaa navigoida samaan sivuun, jätetään se huomiotta
		private NavigationViewItem _lastItem;

		// HUOM! Vaihda tähän oman UWP-projektisi nimi! (näkyy Solution Explorerissa ylimpänä)
		private string projectName = "Harjoitukset";

		// jotain painettiin valikosta, päätetään mitä tehdään
		private void NavigationView_OnItemInvoked(
			Windows.UI.Xaml.Controls.NavigationView sender,
			NavigationViewItemInvokedEventArgs args)
		{
			// haetaan klikattu NavigationViewItem
			var item = args.InvokedItemContainer as NavigationViewItem;

			// jos Itemiä ei löydy, jätetään pyyntö kesken
			if (item == null || item == _lastItem)
				return;

			// jos Itemistä ei löydy Tagia, oletuksena on silloin Settings
			// tässä tapauksessa settingsview on otettu pois käytöstä myös XAMLin puolella
			var clickedView = item.Tag?.ToString() ?? "SettingsView";
			
			// jos navigointi epäonnistuu, jätetään kesken
			if (!NavigateToView(clickedView)) return;

			_lastItem = item;
		}

		// suoritetaan varsinainen navigaatio, tätä kutsuu lähinnä
		// NavigationView_OnItemInvoked
		private bool NavigateToView(string clickedView)
		{
			// yritetään hakea sopiva sivu Views -kansiosta
			var view = Assembly.GetExecutingAssembly()
				.GetType($"{projectName}.Views.{clickedView}");

			// jos haluttua sivua ei löydy, jätetään navigointi kesken
			if (string.IsNullOrWhiteSpace(clickedView) || view == null)
			{
				return false;
			}

			// navigoidaan valittu sivu ContentFrameen
			ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
			return true;
		}

		// jos navigointi epäonnistuu, kaadetaan ohjelma
		private void ContentFrame_OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new NavigationException(
				$"Navigation failed {e.Exception.Message} for {e.SourcePageType.FullName}");
		}

		// käsitellään Back-painike => mennään edelliseen sivuun takaisin
		private void NavView_OnBackRequested(
			Windows.UI.Xaml.Controls.NavigationView sender,
			NavigationViewBackRequestedEventArgs args)
		{
			if (ContentFrame.CanGoBack)
				ContentFrame.GoBack();
		}

    }

    // oma poikkeustyyppi navigointiongelmille
    internal class NavigationException : Exception
	{
		public NavigationException(string msg) : base(msg)
		{

		}
	}

}
