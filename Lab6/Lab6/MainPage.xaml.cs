using Lab6.Models;
using Lab6.Models.AutoComplete;
using Lab6.Models.Forecast;
using Lab6.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab6
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; } = new MainPageViewModel();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Description = "";
            ViewModel.LocationName = "";
            ViewModel.Temperature = "Loading...";
            ViewModel.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3a/Gray_circles_rotate.gif";
            
            
            await UpdateWeather("Seattle,WA");

        }

        private async Task UpdateWeather(string cityLink)
        {
            WeatherRetriever weatherRetriever = new WeatherRetriever();
            ObservationsRootObject observationsRoot = await weatherRetriever.GetObservations(cityLink);
            ViewModel.Description = observationsRoot.response.ob.weatherShort;
            ViewModel.LocationName = observationsRoot.response.place.name + ", " + observationsRoot.response.place.state + " " + observationsRoot.response.place.country;
            ViewModel.Temperature = "" + observationsRoot.response.ob.tempF;
            ViewModel.ImageUrl = GetIconURLFromName(observationsRoot.response.ob.icon);

            ViewModel.Forecast.Clear();
        }

        private string GetIconURLFromName(string iconName)
        {
            return "http://cdn.aerisapi.com/wxblox/icons/" + iconName;
        }

        private async Task SearchForCities(string userText)
        {
            WeatherRetriever weatherRetriever = new WeatherRetriever();
            AutoCompleteRootObject acr = await weatherRetriever.GetSuggestions(userText);

            ViewModel.AutoCompleteNames = new List<string>();
            foreach(Models.AutoComplete.Response resp in acr.response)
            {
                string fullName = resp.place.name;
                if(resp.place.state != null && resp.place.state != "")
                {
                    fullName += "," + resp.place.state;
                }
                fullName += "," + resp.place.country;
                ViewModel.AutoCompleteNames.Add(fullName);
            }
            LocationAutoSuggestBox.ItemsSource = ViewModel.AutoCompleteNames;
        }

        private async void LocationAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                await SearchForCities(LocationAutoSuggestBox.Text);
            }
        }

        private async void LocationAutoSuggestion_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                await UpdateWeather((string)args.ChosenSuggestion);
            } else
            {
                await SearchForCities(args.QueryText);
            }
        }
    }
}
