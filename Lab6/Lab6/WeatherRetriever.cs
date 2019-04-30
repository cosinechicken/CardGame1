using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class WeatherRetriever
    {
        private string apiKey = "HFXQfGjUsgUGg1s2Yr6JJ";
        private string secret = "UCYD8DGUwMzphF6bLFlsIvYVCc62UUspNF784qob";

        public async Task<ObservationsRootObject> GetObservations()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/observations/Seattle,WA,US?client_id={apiKey}&client_secret={secret}";
            string responseString = await httpClient.GetStringAsync(apiUrl);
            ObservationsRootObject observations = JsonConvert.DeserializeObject<ObservationsRootObject>(responseString);
            return observations;
        }
    }
}
