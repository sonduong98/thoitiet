using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Weather
{
    public class WeatherModel
    {
        public int Temp { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public string Description { get; set; }
        public float WindSpeed { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string City { get; set; }
        public string icon { get; set; }
        public int day { get; set; }
        public int Count { get; set; }
        public string img { get; set; }
    }
}
