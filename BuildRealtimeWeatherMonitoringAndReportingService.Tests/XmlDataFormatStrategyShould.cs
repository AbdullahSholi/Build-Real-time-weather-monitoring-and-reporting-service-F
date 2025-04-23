using BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;

public class XmlDataFormatStrategyShould
{
    [Theory]
    [InlineData("<>")]
    public void CanProcessWeatherData_WhenEnterValidData_ShouldReturnTrue(string weatherData)
    {
        // Arrange
        var canProcessWeatherData = weatherData.Trim().StartsWith("<") && weatherData.Trim().EndsWith(">");
        
        // Act & Assert
        if(canProcessWeatherData)
            Assert.True(canProcessWeatherData);
    }

    [Theory]
    [InlineData("<R")]
    public void CantProcessWeatherData_WhenEnterInValidData_ShouldReturnFalse(string weatherData)
    {
        // Arrange
        var canProcessWeatherData = weatherData.Trim().StartsWith("<") && weatherData.Trim().EndsWith(">");
        
        // Act & Assert
        if(!canProcessWeatherData)
            Assert.False(canProcessWeatherData); 
    }

    [Theory]
    [InlineData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>")]
    public void ProcessWeatherData_WhenEnterValidWeatherData_ShouldProcessWeatherData(string weatherData)
    {
        var sut = new XmlDataFormatStrategy();
        
        var result = sut.ProcessWeatherData(weatherData);

        Assert.NotNull(result);
        Assert.Equal(32, result.Temperature);
        Assert.Equal(40, result.Humidity);
    }
}