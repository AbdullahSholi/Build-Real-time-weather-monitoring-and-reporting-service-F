using BuildRealtimeWeatherMonitoringAndReportingService.Entities;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;

public class DataFormatContext
{
    private readonly List<IDataFormatStrategy> _dataFormatStrategies;
    
    public DataFormatContext(IDataFormats dataFormats)
    {
        _dataFormatStrategies = dataFormats.DataFormatStrategies();
    }

    public WeatherData ProcessWeatherData(string weatherData)
    {
        foreach (var dataFormatStrategy in _dataFormatStrategies)
        {
            if(dataFormatStrategy.CanProcessWeatherData(weatherData))
                return dataFormatStrategy.ProcessWeatherData(weatherData);
        }
        
        throw new FormatException("Invalid weather data format");
    }
}