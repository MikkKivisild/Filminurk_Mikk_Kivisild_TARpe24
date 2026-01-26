using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Dto;
using Data;

namespace ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDTO> AccuWeatherResult(AccuLocationWeatherResultDTO dto)
        { 
            string apikey = Data.Enviroment.accuweatherkey;
            var baseUrl = "https://dataservice.accuweather.com/forecasts/v1/daily/1day";
            var cityUrl = $"https://dataservice.accuweather.com/forecasts/v1/cities/search";

            //var locationRespomse = $"https://dataservice.accuweather.com/forecasts/v1/cities/search?apikey={apikey}&q{dto.CityName}";
            using (var HttpClient = new HttpClient()) 
            {
                HttpClient.BaseAddress = new Uri(cityUrl);
                HttpClient.DefaultRequestHeaders.Accept.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );
                var response = HttpClient.GetAsync($"?q={dto.CityName}&apikey={apikey}&details=true").GetAwaiter().GetResult();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                List<AccuCityCodeRootDTO> codeData = JsonSerializer.Deserialize<List<AccuCityCodeRootDTO>>(jsonResponse);
                dto.CityCode = codeData[0].Key;
            }
            string locationResponse = cityUrl+$"?apikey{apikey}&q={dto.CityName}";
            using (var clientLocation = new HttpClient()) 
            {
                var httpResponseLocation = await clientLocation.GetAsync(locationResponse);
                string jsonLocation = await httpResponseLocation.Content.ReadAsStringAsync();
                AccuCityCodeRootDTO cityRootDto = JsonSerializer.Deserialize<AccuCityCodeRootDTO>(jsonLocation);
            }

            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri(cityUrl);
                httpclient.DefaultRequestHeaders.Accept.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );
                var response = httpclient.GetAsync($"{dto.CityCode}?apikey{apikey}&details=true").GetAwaiter().GetResult();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                
                List<AccuCityCodeRootDTO> weatherData = JsonSerializer.Deserialize<List<AccuCityCodeRootDTO>>(jsonResponse);
                dto.CityName = weatherData[0].LocalizedName;
                dto.CityCode = weatherData[0].Key;

            }


            string weatherResponse = baseUrl + $" {dto.CityCode}?apiKey={apikey}&metric=true";

            using (var clientWeather = new HttpClient())
            {
            var httpResponseWeather = clientWeather.GetAsync(weatherResponse).GetAwaiter().GetResult();
                string jsonWeather = await httpResponseWeather.Content.ReadAsStringAsync();

             AccuLocationRootDTO weatherRootDTO = JsonSerializer.Deserialize<AccuLocationRootDTO>(jsonWeather);

            dto.EffectiveDate = weatherRootDTO.Headline.EffectiveDate;
            dto.EffectiveEpochDate = weatherRootDTO.Headline.EffectiveEpochDate;
            dto.Severity = weatherRootDTO.Headline.Severity;
            dto.Text = weatherRootDTO.Headline.Text;
            dto.Category = weatherRootDTO.Headline.Category;
            dto.EndDate = weatherRootDTO.Headline.EndDate;
            dto.EndEpochDate = weatherRootDTO.Headline.EndEpochDate;

            dto.MobileLink = weatherRootDTO.Headline.MoblineLink;
            dto.Link = weatherRootDTO.Headline.Link;

            dto.DailyForecastsDate = weatherRootDTO.DailyForecasts[0].Date;
            dto.DailyForecastsEpochDate = weatherRootDTO.DailyForecasts[0].Date;
            
            dto.TempMinValue = weatherRootDTO.DailyForecasts[0].Temperature.Minimum.Value;
            dto.TempMinUnit = weatherRootDTO.DailyForecasts[0].Temperature.Minimum.Unit;
            dto.TempMinUnitType = weatherRootDTO.DailyForecasts[0].Temperature.Minimum.UnitType;

            dto.TempMaxValue = weatherRootDTO.DailyForecasts[0].Temperature.Maximum.Value;
            dto.TempMaxUnit = weatherRootDTO.DailyForecasts[0].Temperature.Maximum.Unit;
            dto.TempMaxUnitType = weatherRootDTO.DailyForecasts[0].Temperature.Maximum.UnitType;

            dto.DayIcon = weatherRootDTO.DailyForecasts[0].Day.Icon;
            dto.DayIconPhrase = weatherRootDTO.DailyForecasts[0].Day.IconPhrase;
            dto.DayHasPrecipitation = weatherRootDTO.DailyForecasts[0].Day.HasPrecipitation;
            dto.DayHasPrecipitationType = weatherRootDTO.DailyForecasts[0].Day.PrecipitationType;
            dto.DayHasPrecipitationIntensity = weatherRootDTO.DailyForecasts[0].Day.PrecipitationIntensity;

            dto.NightIcon = weatherRootDTO.DailyForecasts[0].Night.Icon;
            dto.NightIconPhrase = weatherRootDTO.DailyForecasts[0].Night.IconPhrase;
            dto.NightHasPrecipitation = weatherRootDTO.DailyForecasts[0].Night.HasPrecipitation;
            dto.NightHasPrecipitationType = weatherRootDTO.DailyForecasts[0].Night.PrecipitationType;
            dto.NightHasPrecipitationIntensity = weatherRootDTO.DailyForecasts[0].Night.PrecipitationIntensity;
          }
          return dto;
        }
    }
}
