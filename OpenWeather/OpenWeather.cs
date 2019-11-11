using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.OpenWeather
{
    class OpenWeather
    {
        [JsonProperty("base")]
        public coord coord;
        public weather[] weather;
        public string Base;
        public main main;
        public double visibility;
        public wind wind;
        public clouds clouds;
        public double dt;
        public sys sys;
        public int id;
        public string name;
        public double code;
    }
}
