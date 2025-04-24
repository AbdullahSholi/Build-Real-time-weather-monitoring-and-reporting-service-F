using System.Xml.Serialization;
using BuildRealtimeWeatherMonitoringAndReportingService;
using BuildRealtimeWeatherMonitoringAndReportingService.CustomMessages;
using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;
using BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Read File Content 
        string configurationsFilePath = @"..\..\..\Config\ConfigurationsFile.json";
        JObject configurationsFileContent = DeserializeJsonStringToJObject.ReadConfigurations(configurationsFilePath);
        
        // User Input
        Console.WriteLine(CustomMessage.EnterWeatherDataMessage);
        var weatherData = Console.ReadLine();
        
        // Strategy Design Pattern
        IDataFormats dataFormats = new DataFormats();
        DataFormatContext dataFormatContext = new DataFormatContext(dataFormats);
        var userInput = dataFormatContext.ProcessWeatherData(weatherData);
        
        // Observer Design Pattern
        ISubject weatherStation = new WeatherStation();
        
        
        bool isRainy = userInput.Humidity > configurationsFileContent["RainBot"]["humidityThreshold"].ToObject<decimal>();
        bool isSunny = userInput.Temperature > configurationsFileContent["SunBot"]["temperatureThreshold"].ToObject<decimal>();
        bool isSnow = userInput.Temperature < configurationsFileContent["SnowBot"]["temperatureThreshold"].ToObject<decimal>();

        configurationsFileContent["RainBot"]["enabled"] = isRainy;
        configurationsFileContent["SunBot"]["enabled"] = isSunny;
        configurationsFileContent["SnowBot"]["enabled"] = isSnow;
        
        IObserver rainBot = new RainBot(configurationsFileContent["RainBot"]["message"].ToObject<string>());
        IObserver sunBot = new SunBot(configurationsFileContent["SunBot"]["message"].ToObject<string>());
        IObserver snowBot = new SnowBot(configurationsFileContent["SnowBot"]["message"].ToObject<string>());
        
        if (configurationsFileContent["RainBot"]["enabled"].ToObject<Boolean>())
        {
            weatherStation.AddObserver(rainBot);
        }

        if (configurationsFileContent["SunBot"]["enabled"].ToObject<Boolean>())
        {
            weatherStation.AddObserver(sunBot);
        }

        if (configurationsFileContent["SnowBot"]["enabled"].ToObject<Boolean>())
        {
            weatherStation.AddObserver(snowBot);
        }
        
        weatherStation.NotifyObservers();
        
    }
    
}