using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models.Forecast
{
    public class Loc
    {
        public double? @long { get; set; }
        public double? lat { get; set; }
    }

    public class Period
    {
        public double? timestamp { get; set; }
        public DateTime validTime { get; set; }
        public DateTime dateTimeISO { get; set; }
        public double? maxTempC { get; set; }
        public double? maxTempF { get; set; }
        public double? minTempC { get; set; }
        public double? minTempF { get; set; }
        public double? avgTempC { get; set; }
        public double? avgTempF { get; set; }
        public object tempC { get; set; }
        public object tempF { get; set; }
        public double? pop { get; set; }
        public double? precipMM { get; set; }
        public double? precipIN { get; set; }
        public double? iceaccum { get; set; }
        public double? iceaccumMM { get; set; }
        public double? iceaccumIN { get; set; }
        public double? maxHumidity { get; set; }
        public double? minHumidity { get; set; }
        public double? humidity { get; set; }
        public double? uvi { get; set; }
        public double? pressureMB { get; set; }
        public double? pressureIN { get; set; }
        public double? sky { get; set; }
        public double? snowCM { get; set; }
        public double? snowIN { get; set; }
        public double? feelslikeC { get; set; }
        public double? feelslikeF { get; set; }
        public double? minFeelslikeC { get; set; }
        public double? minFeelslikeF { get; set; }
        public double? maxFeelslikeC { get; set; }
        public double? maxFeelslikeF { get; set; }
        public double? avgFeelslikeC { get; set; }
        public double? avgFeelslikeF { get; set; }
        public double? dewpointC { get; set; }
        public double? dewpointF { get; set; }
        public double? maxDewpointC { get; set; }
        public double? maxDewpointF { get; set; }
        public double? minDewpointC { get; set; }
        public double? minDewpointF { get; set; }
        public double? avgDewpointC { get; set; }
        public double? avgDewpointF { get; set; }
        public double? windDirDEG { get; set; }
        public string windDir { get; set; }
        public double? windDirMaxDEG { get; set; }
        public string windDirMax { get; set; }
        public double? windDirMinDEG { get; set; }
        public string windDirMin { get; set; }
        public double? windGustKTS { get; set; }
        public double? windGustKPH { get; set; }
        public double? windGustMPH { get; set; }
        public double? windSpeedKTS { get; set; }
        public double? windSpeedKPH { get; set; }
        public double? windSpeedMPH { get; set; }
        public double? windSpeedMaxKTS { get; set; }
        public double? windSpeedMaxKPH { get; set; }
        public double? windSpeedMaxMPH { get; set; }
        public double? windSpeedMinKTS { get; set; }
        public double? windSpeedMinKPH { get; set; }
        public double? windSpeedMinMPH { get; set; }
        public double? windDir80mDEG { get; set; }
        public string windDir80m { get; set; }
        public double? windDirMax80mDEG { get; set; }
        public string windDirMax80m { get; set; }
        public double? windDirMin80mDEG { get; set; }
        public string windDirMin80m { get; set; }
        public double? windGust80mKTS { get; set; }
        public double? windGust80mKPH { get; set; }
        public double? windGust80mMPH { get; set; }
        public double? windSpeed80mKTS { get; set; }
        public double? windSpeed80mKPH { get; set; }
        public double? windSpeed80mMPH { get; set; }
        public double? windSpeedMax80mKTS { get; set; }
        public double? windSpeedMax80mKPH { get; set; }
        public double? windSpeedMax80mMPH { get; set; }
        public double? windSpeedMin80mKTS { get; set; }
        public double? windSpeedMin80mKPH { get; set; }
        public double? windSpeedMin80mMPH { get; set; }
        public string weather { get; set; }
        public List<object> weatherCoded { get; set; }
        public string weatherPrimary { get; set; }
        public string weatherPrimaryCoded { get; set; }
        public string cloudsCoded { get; set; }
        public string icon { get; set; }
        public bool isDay { get; set; }
        public double? sunrise { get; set; }
        public DateTime sunriseISO { get; set; }
        public double? sunset { get; set; }
        public DateTime sunsetISO { get; set; }
    }

    public class Profile
    {
        public string tz { get; set; }
    }

    public class Response
    {
        public Loc loc { get; set; }
        public string interval { get; set; }
        public List<Period> periods { get; set; }
        public Profile profile { get; set; }
    }

    public class ForecastRootObject
    {
        public bool success { get; set; }
        public object error { get; set; }
        public List<Response> response { get; set; }
    }
}
