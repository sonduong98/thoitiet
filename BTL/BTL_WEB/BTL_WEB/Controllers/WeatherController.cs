using System.Net.Http;
using System.Web.Mvc;
namespace BTL_WEB.Controllers
{
    using Business;
    using Models.Weather;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;

    public class WeatherController : Controller
    {
        int count = 0;
        int tempFirst;
        private ApplicationService _applicationService = new ApplicationService();
        // GET: Weather
        ListWeatherByProvince model = new ListWeatherByProvince();
        public void FetchWeatherProvince(string nameProvince,string img)
        {
            HttpClient http = new HttpClient();

            string api = "http://api.openweathermap.org/data/2.5/weather?q=" + nameProvince + "&appid=dac1be3433ca48145eb2b8b7782e99f9";

            var data = http.GetAsync(api).Result.Content.ReadAsStringAsync().Result;

            dynamic json = JsonConvert.DeserializeObject(data);
            if(json != null && json["cod"] != "404")
            {
                model.CurrenceWeater.Add(new WeatherModel()
                {
                    TempMax = (int)json["main"]["temp"],

                    Description = (string)json["weather"][0]["description"],

                    WindSpeed = json["wind"]["speed"] * 3.6,

                    Date = DateTime.Now.ToString(),

                    City = nameProvince,

                    icon = icon((string)json["weather"][0]["description"]),
                    img = img
                });
            }
            
        }
        public void FetchDetailWeatherProvince(string nameProvince)
        {
            HttpClient http = new HttpClient();

            string api = "http://api.openweathermap.org/data/2.5/forecast?q=" + nameProvince + "&appid=dac1be3433ca48145eb2b8b7782e99f9";

            var data = http.GetAsync(api).Result.Content.ReadAsStringAsync().Result;

            dynamic json = JsonConvert.DeserializeObject(data);

            for (var i = 0; i < json["list"].Count; i++)
            {
                if (i > 0)
                {
                    if (model.CurrenceWeater[i - 1].Date != Convert.ToDateTime(json["list"][i]["dt_txt"]).ToString("yyyy-MM-dd"))
                    {
                        count++;
                    }
                }               
                model.CurrenceWeater.Add(new WeatherModel()
                {

                    Temp = (int)json["list"][i]["main"]["temp"] - 273,

                    TempMax = (int)json["list"][i]["main"]["temp_max"] - 273,

                    TempMin = (int)json["list"][i]["main"]["temp_min"] - 273,

                    WindSpeed = json["list"][i]["wind"]["speed"] * 3.6,
                 
                    Date = Convert.ToDateTime(json["list"][i]["dt_txt"]).ToString("yyyy-MM-dd"),

                    City = nameProvince,

                    day = (int)Convert.ToDateTime(json["list"][i]["dt_txt"]).DayOfWeek,

                    Count = count  
                }); ;
            }
        }

        public ActionResult VietNam(string keyword)
        {
            if(keyword != null)
            {
                ViewData["PageInfo"] = _applicationService.InfoLayout();
                FetchWeatherProvince(keyword, "haiphong1.jpg");
                if(model.CurrenceWeater == null)
                {
                    model.msg = "Không tìm thấy dữ liệu bạn cần tìm!";
                }
                return View(model);
            }
            else
            {
                ViewData["PageInfo"] = _applicationService.InfoLayout();

                FetchWeatherProvince("Ha Noi", "hanoi2.jpg");

                FetchWeatherProvince("SaiGon", "HCM.jpg");

                FetchWeatherProvince("Vinh", "nghean.jpg");

                FetchWeatherProvince("HaiPhong", "haiphong1.jpg");

                FetchWeatherProvince("Hue", "hue1.jpg");

                FetchWeatherProvince("Pleiku", "pleiku.jpg");

                FetchWeatherProvince("Da Lat", "dalat.jpg.jpg");

                FetchWeatherProvince("DaNang", "danang.jpg");

                FetchWeatherProvince("NhaTrang", "haiphong1.jpg");

                return View(model);
            }
            
        }
        public string icon(string des)
        {
            string data = "fas fa-cloud-sun";

            if (des == "broken clouds" || des == "scattered clouds" || des == "few clouds")

                data = "fas fa-cloud-sun";

            if (des == "overcast clouds")

                data = "fas fa-cloud-showers-heavy";

            return data;
        }
        [HttpGet]
        public ActionResult WeatherDetail(string city)
        {
            HttpClient http = new HttpClient();

            string api = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=dac1be3433ca48145eb2b8b7782e99f9";

            var data = http.GetAsync(api).Result.Content.ReadAsStringAsync().Result;

            dynamic json = JsonConvert.DeserializeObject(data);

            tempFirst = (int)json["main"]["temp"]-273;

            FetchDetailWeatherProvince(city);

            for(var i = 0; i < 6; i++)
            {
                WeatherModel dataTempMax = model.CurrenceWeater.Where(c=>c.Count==i).OrderByDescending(u => u.TempMax).FirstOrDefault();

                WeatherModel dataTempMin = model.CurrenceWeater.Where(c => c.Count == i).OrderBy(u => u.TempMax).FirstOrDefault();
                if (i == 0)
                {
                    model.Forecast6Days.Add(new WeatherModel()
                    {
                        Temp = tempFirst,

                        TempMax = dataTempMax.TempMax,

                        TempMin = dataTempMin.TempMin,

                        WindSpeed = dataTempMax.WindSpeed,

                        Date = dataTempMax.Date,

                        day = dataTempMax.day,

                        City = dataTempMax.City
                    });
                }
                else
                {
                    model.Forecast6Days.Add(new WeatherModel()
                    {
                        Temp = dataTempMax.Temp,

                        TempMax = dataTempMax.TempMax,

                        TempMin = dataTempMin.TempMin,

                        WindSpeed = dataTempMax.WindSpeed,

                        Date = dataTempMax.Date,

                        day = dataTempMax.day,

                        City = dataTempMax.City
                    });
                }
                

            }
            //WeatherModel data = model.CurrenceWeater.OrderByDescending(u => u.TempMax).FirstOrDefault();

            return View(model);
        }
    }
}