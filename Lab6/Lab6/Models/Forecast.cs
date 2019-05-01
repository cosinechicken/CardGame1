using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models.Forecast
{
    public class Loc
    {
        public double @long { get; set; }
        public double lat { get; set; }
    }

    public class Period
    {
        public int timestamp { get; set; }
        public DateTime validTime { get; set; }
        public DateTime dateTimeISO { get; set; }
        public int maxTempC { get; set; }
        public int maxTempF { get; set; }
        public int minTempC { get; set; }
        public int minTempF { get; set; }
        public int avgTempC { get; set; }
        public int avgTempF { get; set; }
        public object tempC { get; set; }
        public object tempF { get; set; }
        public int pop { get; set; }
        public int precipMM { get; set; }
        public int precipIN { get; set; }
        public int? iceaccum { get; set; }
        public int? iceaccumMM { get; set; }
        public int? iceaccumIN { get; set; }
        public int maxHumidity { get; set; }
        public int minHumidity { get; set; }
        public int humidity { get; set; }
        public int uvi { get; set; }
        public int pressureMB { get; set; }
        public double pressureIN { get; set; }
        public int sky { get; set; }
        public int snowCM { get; set; }
        public int snowIN { get; set; }
        public int feelslikeC { get; set; }
        public int feelslikeF { get; set; }
        public int minFeelslikeC { get; set; }
        public int minFeelslikeF { get; set; }
        public int maxFeelslikeC { get; set; }
        public int maxFeelslikeF { get; set; }
        public int avgFeelslikeC { get; set; }
        public int avgFeelslikeF { get; set; }
        public int dewpointC { get; set; }
        public int dewpointF { get; set; }
        public int maxDewpointC { get; set; }
        public int maxDewpointF { get; set; }
        public int minDewpointC { get; set; }
        public int minDewpointF { get; set; }
        public int avgDewpointC { get; set; }
        public int avgDewpointF { get; set; }
        public int windDirDEG { get; set; }
        public string windDir { get; set; }
        public int windDirMaxDEG { get; set; }
        public string windDirMax { get; set; }
        public int windDirMinDEG { get; set; }
        public string windDirMin { get; set; }
        public int windGustKTS { get; set; }
        public int windGustKPH { get; set; }
        public int windGustMPH { get; set; }
        public int windSpeedKTS { get; set; }
        public int windSpeedKPH { get; set; }
        public int windSpeedMPH { get; set; }
        public int windSpeedMaxKTS { get; set; }
        public int windSpeedMaxKPH { get; set; }
        public int windSpeedMaxMPH { get; set; }
        public int windSpeedMinKTS { get; set; }
        public int windSpeedMinKPH { get; set; }
        public int windSpeedMinMPH { get; set; }
        public int windDir80mDEG { get; set; }
        public string windDir80m { get; set; }
        public int windDirMax80mDEG { get; set; }
        public string windDirMax80m { get; set; }
        public int windDirMin80mDEG { get; set; }
        public string windDirMin80m { get; set; }
        public int windGust80mKTS { get; set; }
        public int windGust80mKPH { get; set; }
        public int windGust80mMPH { get; set; }
        public int windSpeed80mKTS { get; set; }
        public int windSpeed80mKPH { get; set; }
        public int windSpeed80mMPH { get; set; }
        public int windSpeedMax80mKTS { get; set; }
        public int windSpeedMax80mKPH { get; set; }
        public int windSpeedMax80mMPH { get; set; }
        public int windSpeedMin80mKTS { get; set; }
        public int windSpeedMin80mKPH { get; set; }
        public int windSpeedMin80mMPH { get; set; }
        public string weather { get; set; }
        public List<object> weatherCoded { get; set; }
        public string weatherPrimary { get; set; }
        public string weatherPrimaryCoded { get; set; }
        public string cloudsCoded { get; set; }
        public string icon { get; set; }
        public bool isDay { get; set; }
        public int sunrise { get; set; }
        public DateTime sunriseISO { get; set; }
        public int sunset { get; set; }
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
