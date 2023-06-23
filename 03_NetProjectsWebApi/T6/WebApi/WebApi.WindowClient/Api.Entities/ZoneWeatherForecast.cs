namespace Api.Entities
{
    public class ZoneWeatherForecast
    {
        public Zone Zone { get; set; }
        public IEnumerable<WeatherForecast> WeatherForecast { get; set; }
    }
}
