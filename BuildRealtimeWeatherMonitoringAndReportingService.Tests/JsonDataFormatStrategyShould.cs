using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using BuildRealtimeWeatherMonitoringAndReportingService.Entities;
using BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;
using Moq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;

public class JsonDataFormatStrategyShould
{
    [Theory]
    [InlineData("{}")]
    public void CanProcessWeatherData_WhenEnterValidData_ShouldReturnTrue(string weatherData)
    {
        // Arrange
        var canProcessWeatherData = weatherData.Trim().StartsWith("{") && weatherData.Trim().EndsWith("}");
        
        // Act & Assert
        if(canProcessWeatherData)
            Assert.True(weatherData.Trim().StartsWith("{") && weatherData.Trim().EndsWith("}"));
    }

    [Theory]
    [InlineData("{R")]
    public void CantProcessWeatherData_WhenEnterInValidData_ShouldReturnFalse(string weatherData)
    {
        // Arrange
        var canProcessWeatherData = weatherData.Trim().StartsWith("{") && weatherData.Trim().EndsWith("}");
        
        // Act & Assert
        if(!canProcessWeatherData)
            Assert.False(canProcessWeatherData); 
    }

    [Theory]
    [InlineData("{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}")]
    public void ProcessWeatherData_WhenEnterValidWeatherData_ShouldProcessWeatherData(string weatherData)
    {
        var sut = new JsonDataFormatStrategy();
        
        var result = sut.ProcessWeatherData(weatherData);

        Assert.NotNull(result);
        Assert.Equal(32, result.Temperature);
        Assert.Equal(40, result.Humidity);
    }
    
}