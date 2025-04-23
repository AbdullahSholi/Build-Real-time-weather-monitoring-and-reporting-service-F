using System.Xml.Serialization;
using BuildRealtimeWeatherMonitoringAndReportingService;
using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string configurationsFilePath = @"..\..\..\Config\ConfigurationsFile.json";
        JObject configurationsFileContent = DeserializeJsonStringToJObject.ReadConfigurations(configurationsFilePath);
        Console.WriteLine(configurationsFileContent);
        
        Console.WriteLine(CustomMessage.EnterWeatherData);
        var weatherData = Console.ReadLine();
        
        DataFormats dataFormats = new DataFormats();
        DataFormatContext dataFormatContext = new DataFormatContext(dataFormats);
        var result = dataFormatContext.ProcessWeatherData(weatherData);
        Console.WriteLine(result.Humidity);
        
    }
    
}