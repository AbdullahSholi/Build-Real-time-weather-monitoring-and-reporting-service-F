using Newtonsoft.Json.Linq;
namespace BuildRealtimeWeatherMonitoringAndReportingService;

public class ConfigurationsFileReader
{
    public void ReadConfigurations()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string file = Path.Combine(currentDirectory, @"..\..\..\ConfigurationsFile.json");
        string filePath = Path.GetFullPath(file);
        
        var json = File.ReadAllText(filePath);
        JObject jsonResult = JObject.Parse(json);
        Console.WriteLine(jsonResult);
    }
    
}