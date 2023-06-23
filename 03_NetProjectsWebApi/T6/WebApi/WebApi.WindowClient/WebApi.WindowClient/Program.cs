using Api.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.WindowClient;

namespace Web.Api.WindowClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GetIo();
            System.Threading.Thread.Sleep(5000);

            var forecast = GetWeatherForecastAsync(new Zone
            {
                City ="Acapulco",
                Date = new DateTime(2021, 10, 20)
            }).Result;

            Console.WriteLine("Ciudad: "+forecast.Zone.City);
            Console.WriteLine("Fecha: " + forecast.Zone.Date);

            foreach (var item in forecast.WeatherForecast)
            {
                Console.WriteLine("");
                Console.WriteLine("Summary: " + item.Summary);
                Console.WriteLine("TemperatureC: " + item.TemperatureC);
                Console.WriteLine("TemperatureF: " + item.TemperatureF);

            }

            Console.ReadLine();
        }

        private static async Task<ZoneWeatherForecast> GetWeatherForecastAsync(Zone zone)
        {
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(zone);
            HttpClient client = new HttpClient();



            HttpResponseMessage response = await client.PostAsync("https://localhost:7198/weatherforecast/byzone", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            string respondeBody = await response.Content.ReadAsStringAsync();

            ZoneWeatherForecast forecast = Newtonsoft.Json.JsonConvert.DeserializeObject<ZoneWeatherForecast>(respondeBody);

           // Console.WriteLine("My current Ip Adrees is: " + ip.Ip);

//            var info = await GetIpInfo(ip.Ip);

  //          Console.WriteLine("Country: " + info.Country);
      //      Console.WriteLine("City: " + info.City);
    //        Console.WriteLine("TimeZone: " + info.TimeZone);

            return forecast;
        }

        private static async Task<IpAdress> GetIo()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.ipify.org/?format=json");
            response.EnsureSuccessStatusCode();

            string respondeBody = await response.Content.ReadAsStringAsync();

            IpAdress ip = Newtonsoft.Json.JsonConvert.DeserializeObject<IpAdress>(respondeBody);

            Console.WriteLine("My current Ip Adrees is: "+ip.Ip);

            var info = await GetIpInfo(ip.Ip);

            Console.WriteLine("Country: " + info.Country);
            Console.WriteLine("City: " + info.City);
            Console.WriteLine("TimeZone: " + info.TimeZone);

            return ip;
        }


        private static async Task<IpInfo> GetIpInfo(string ip)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://ipinfo.io/{ip}/geo");
            response.EnsureSuccessStatusCode();

            string respondeBody = await response.Content.ReadAsStringAsync();

            IpInfo ipInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfo>(respondeBody);


            return ipInfo;
        }
    }
}
