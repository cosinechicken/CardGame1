using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class Loc
    {
        public double? @long { get; set; }
        public double? lat { get; set; }
    }

    public class Place
    {
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class Profile
    {
        public string tz { get; set; }
        public double? elevM { get; set; }
        public double? elevFT { get; set; }
    }

    public class Ob
    {
        public double? timestamp { get; set; }
        public DateTime dateTimeISO { get; set; }
        public double? tempC { get; set; }
        public double? tempF { get; set; }
        public double? dewpodoubleC { get; set; }
        public double? dewpodoubleF { get; set; }
        public double? humidity { get; set; }
        public double? pressureMB { get; set; }
        public double? pressureIN { get; set; }
        public double? spressureMB { get; set; }
        public double? spressureIN { get; set; }
        public double? altimeterMB { get; set; }
        public double? altimeterIN { get; set; }
        public double? windKTS { get; set; }
        public double? windKPH { get; set; }
        public double? windMPH { get; set; }
        public double? windSpeedKTS { get; set; }
        public double? windSpeedKPH { get; set; }
        public double? windSpeedMPH { get; set; }
        public double? windDirDEG { get; set; }
        public string windDir { get; set; }
        public object windGustKTS { get; set; }
        public object windGustKPH { get; set; }
        public object windGustMPH { get; set; }
        public string flightRule { get; set; }
        public double? visibilityKM { get; set; }
        public double? visibilityMI { get; set; }
        public string weather { get; set; }
        public string weatherShort { get; set; }
        public string weatherCoded { get; set; }
        public string weatherPrimary { get; set; }
        public string weatherPrimaryCoded { get; set; }
        public string cloudsCoded { get; set; }
        public string icon { get; set; }
        public double? heatindexC { get; set; }
        public double? heatindexF { get; set; }
        public double? windchillC { get; set; }
        public double? windchillF { get; set; }
        public double? feelslikeC { get; set; }
        public double? feelslikeF { get; set; }
        public bool isDay { get; set; }
        public double? sunrise { get; set; }
        public DateTime sunriseISO { get; set; }
        public double? sunset { get; set; }
        public DateTime sunsetISO { get; set; }
        public object snowDepthCM { get; set; }
        public object snowDepthIN { get; set; }
        public double? precipMM { get; set; }
        public double? precipIN { get; set; }
        public double? solradWM2 { get; set; }
        public string solradMethod { get; set; }
        public object ceilingFT { get; set; }
        public object ceilingM { get; set; }
        public double? light { get; set; }
        public string QC { get; set; }
        public double? QCcode { get; set; }
        public double? sky { get; set; }
    }

    public class RelativeTo
    {
        public double? lat { get; set; }
        public double? @long { get; set; }
        public double? bearing { get; set; }
        public string bearingENG { get; set; }
        public double? distanceKM { get; set; }
        public double? distanceMI { get; set; }
    }

    public class Response
    {
        public string id { get; set; }
        public Loc loc { get; set; }
        public Place place { get; set; }
        public Profile profile { get; set; }
        public double? obTimestamp { get; set; }
        public DateTime obDateTime { get; set; }
        public Ob ob { get; set; }
        public string raw { get; set; }
        public RelativeTo relativeTo { get; set; }
    }

    public class ObservationsRootObject
    {
        public bool success { get; set; }
        public object error { get; set; }
        public Response response { get; set; }
    }
}
