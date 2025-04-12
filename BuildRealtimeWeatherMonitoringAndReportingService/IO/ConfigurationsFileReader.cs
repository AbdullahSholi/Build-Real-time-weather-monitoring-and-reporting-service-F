using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using Newtonsoft.Json.Linq;
namespace BuildRealtimeWeatherMonitoringAndReportingService.IO;

public class ConfigurationsFileReader
{
    private static string ReadConfigurationsFilePath(string configurationsFilePath)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string file = Path.Combine(currentDirectory, configurationsFilePath);
        string filePath = Path.GetFullPath(file);
        return filePath;
    }

    public static string ReadConfigurationsFileContent(string configurationsFilePath)
    {
        string filePath = ReadConfigurationsFilePath(configurationsFilePath);
        var stringJson = File.ReadAllText(filePath);
        return stringJson;
    }
    
    
}