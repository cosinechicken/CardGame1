using Lab6.Models;
using Lab6.Models.AutoComplete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class WeatherRetriever
    {
        private string apiKey = "HFXQfGjUsgUGg1s2Yr6JJ";
        private string secret = "UCYD8DGUwMzphF6bLFlsIvYVCc62UUspNF784qob";

        public async Task<ObservationsRootObject> GetObservations(string cityLink)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/observations/{cityLink}?client_id={apiKey}&client_secret={secret}";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            ObservationsRootObject observations = JsonConvert.DeserializeObject<ObservationsRootObject>(responseString);
            return observations;
        }

        public async Task<AutoCompleteRootObject> GetSuggestions(string enteredStr)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/places/search?query=name:^{enteredStr}&limit=10&client_id={apiKey}&client_secret={secret}";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            AutoCompleteRootObject suggestions = JsonConvert.DeserializeObject<AutoCompleteRootObject>(responseString);
            return suggestions;
        }
    }
}

