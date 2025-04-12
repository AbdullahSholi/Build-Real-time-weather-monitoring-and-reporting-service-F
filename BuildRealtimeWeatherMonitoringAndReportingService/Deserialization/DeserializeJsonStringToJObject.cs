using Newtonsoft.Json.Linq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;

public class DeserializeJsonStringToJObject
{
    public static JObject ReadConfigurations(string fileSubPath)
    {
        var stringJson = ConfigurationsFileReader.ReadConfigurationsFileContent(fileSubPath);
        JObject configurationsFileContent = JObject.Parse(stringJson);
        
        return configurationsFileContent;
    }
}