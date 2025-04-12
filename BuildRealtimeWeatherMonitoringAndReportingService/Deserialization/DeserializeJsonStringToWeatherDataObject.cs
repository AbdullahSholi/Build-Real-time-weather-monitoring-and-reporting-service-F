using Newtonsoft.Json.Linq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;

public class DeserializeStringToWeatherDataObject
{
    public static WeatherData DeserializeJsonStringToWeatherDataObject(string toDeserialize)
    {
        JObject deserializer = JObject.Parse(toDeserialize);
        WeatherData weatherData = (WeatherData)deserializer.ToObject<WeatherData>();
        return weatherData;
    }
}