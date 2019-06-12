using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Warcraft_DiscordBot.Model;

namespace Warcraft_DiscordBot.Modules
{
    public class Weather : ModuleBase<SocketCommandContext>
    {
        private readonly HttpClient _client = new HttpClient();

        [Command("forecast")]
        public async Task WeatherForecast(string city)
        {
            var result = await GetWeatherForeCastData(city.ToLower());

            var date = DateTime.Now.AddDays(1);
            var onlyDate = date.Date.ToString("yyyy-MM-dd");
            var forecastDay = result.Forecast.Forecastday.Single(x => x.Date == onlyDate);
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle($"Forecast for {forecastDay.Day} at {result.Location.Name} - {result.Location.Country}")
                .WithDescription($"Condition: {forecastDay.Day.condition.Text} \nTemp: {forecastDay.Day.avgtemp_c}")
                .WithImageUrl("http:" + forecastDay.Day.condition.Icon)
                .WithColor(Color.Green)
                .WithCurrentTimestamp();

            await ReplyAsync("", false, builder.Build());
        }

        [Command("weather")]
        public async Task WeatherByCityCommand(string city)
        {
            var result = await GetWeatherData(city.ToLower());
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle($"Current Weather at {result.Location.Name} - {result.Location.Country}")
                .WithDescription($"Condition: {result.Current.Condition.Text} \nTemp: {result.Current.Temp_c}C " +
                $"\nHumidity: {result.Current.Humidity}% \nWind Direction: {result.Current.Wind_dir} \nWind Speed: {result.Current.Wind_kph}km/h")
                .WithFooter($"Updated: {result.Current.Last_updated}")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithImageUrl("http:" + result.Current.Condition.Icon);

            await ReplyAsync("", false, builder.Build());
        }

        public async Task<WeatherModel> GetWeatherData(string city)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var key = config["AppSettings:WeatherApiKey"];

            var url = "http://api.apixu.com/v1/current.json?key=" + key + "&q=" + city;

            var jsonResponds = await _client.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<WeatherModel>(jsonResponds);

            return result;
        }

        public async Task<WeatherModel> GetWeatherForeCastData(string city)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var key = config["AppSettings:WeatherApiKey"];

            var url = "http://api.apixu.com/v1/forecast.json?key=" + key + "&q=" + city + "&days=" + 2;
            var jsonResponds = await _client.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<WeatherModel>(jsonResponds);

            return result;
        }
    }
}
