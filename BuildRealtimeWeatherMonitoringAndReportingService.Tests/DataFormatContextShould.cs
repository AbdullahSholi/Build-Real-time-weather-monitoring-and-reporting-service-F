using BuildRealtimeWeatherMonitoringAndReportingService.Entities;
using BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;
using Moq;
using Newtonsoft.Json.Linq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;

public class DataFormatContextShould
{
    [Theory]
    [InlineData(@"<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>")]
    [InlineData(@"{""Location"": ""City Name"", ""Temperature"": 32, ""Humidity"": 40}")]
    public void ProcessWeatherData_WhenEnterValidData_ThenReturnActivatedWeatherBots(string weatherData)
    {
        // Arrange
        var mockedObject = new Mock<IDataFormatStrategy>();
        mockedObject.Setup(x => x.CanProcessWeatherData(weatherData)).Returns(true);
        mockedObject.Setup(x => x.ProcessWeatherData(weatherData)).Returns(It.IsAny<WeatherData>());
        
        var mockedDbFormats = new Mock<IDataFormats>();
        mockedDbFormats
            .Setup( db => db.DataFormatStrategies())
            .Returns(new List<IDataFormatStrategy> { mockedObject.Object });
        var sut = new DataFormatContext(mockedDbFormats.Object);
        
        // Act
        var result = sut.ProcessWeatherData(weatherData);
        
        // Assert
        Assert.Equal(It.IsAny<WeatherData>(), result);
    }

    [Theory]
    [InlineData("GG")]
    public void ProcessWeatherData_WhenEnterInvalidData_ThenThrowException(string weatherData)
    {
        // Arrange
        var mockedObject = new Mock<IDataFormatStrategy>();
        mockedObject.Setup(x => x.CanProcessWeatherData(weatherData)).Returns(false);
        var mockedDbFormats = new Mock<IDataFormats>();
        mockedDbFormats
            .Setup( db => db.DataFormatStrategies())
            .Returns(new List<IDataFormatStrategy> { mockedObject.Object });
        var sut = new DataFormatContext(mockedDbFormats.Object);
        
        // Act && Assert
        var exception = Assert.Throws<FormatException>(() => sut.ProcessWeatherData(weatherData));
        Assert.Equal("Invalid weather data format", exception.Message);
    }
}