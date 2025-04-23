using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;

namespace BuildRealtimeWeatherMonitoringAndReportingService;

public class JsonDataFormatStrategy : IDataFormatStrategy
{
    public bool CanProcessWeatherData(string weatherData)
    {
        return weatherData.Trim().StartsWith("{") && weatherData.Trim().EndsWith("}");
    }

    public WeatherData ProcessWeatherData(string weatherData)
    {
        WeatherData jsonWeatherData = DeserializeStringToWeatherDataObject.DeserializeJsonStringToWeatherDataObject(weatherData);
        return jsonWeatherData;
    }
}