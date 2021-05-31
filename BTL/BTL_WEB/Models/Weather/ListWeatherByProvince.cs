using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Weather
{
    public class ListWeatherByProvince
    {
        public ListWeatherByProvince()
        {
            CurrenceWeater = new List<WeatherModel>();
            Forecast6Days=new List<WeatherModel>();
        }
        public List<WeatherModel> CurrenceWeater { get; set; }
        public List<WeatherModel> Forecast6Days { get; set; }
        public string msg { get; set; }
    }
}
