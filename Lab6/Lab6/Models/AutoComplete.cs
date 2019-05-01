using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models.AutoComplete
{
    public class Loc
    {
        public double lat { get; set; }
        public double @long { get; set; }
    }

    public class Place
    {
        public string name { get; set; }
        public string state { get; set; }
        public string stateFull { get; set; }
        public string country { get; set; }
        public string countryFull { get; set; }
        public string region { get; set; }
        public string regionFull { get; set; }
        public string continent { get; set; }
        public string continentFull { get; set; }
    }

    public class Profile
    {
        public int elevM { get; set; }
        public int elevFT { get; set; }
        public int pop { get; set; }
        public string tz { get; set; }
        public string tzname { get; set; }
        public int tzoffset { get; set; }
        public bool isDST { get; set; }
        public List<string> wxzone { get; set; }
        public List<string> firezone { get; set; }
        public List<string> fips { get; set; }
        public List<string> countyid { get; set; }
    }

    public class Response
    {
        public Loc loc { get; set; }
        public Place place { get; set; }
        public Profile profile { get; set; }
    }

    public class AutoCompleteRootObject
    {
        public bool success { get; set; }
        public object error { get; set; }
        public List<Response> response { get; set; }
    }
}
