using BuildRealtimeWeatherMonitoringAndReportingService.IO;
using Moq;
using Xunit.Abstractions;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;

public class ConfigurationsFileReaderShould
{
    private readonly ITestOutputHelper _testOutputHelper;
    public ConfigurationsFileReaderShould(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    [Theory]
    [InlineData(@"..\..\..\..\BuildRealtimeWeatherMonitoringAndReportingService\Config\ConfigurationsFile.json", true)]
    [InlineData(@"\", false)]
    public void ReadConfigurationsFilePath_WhenProvidePath_ThenValidateThePath(string configurationsFilePath, bool shouldExist)
    {
        // Arrange
        string currentDirectory = Directory.GetCurrentDirectory();
        string fullFilePath = Path.Combine(currentDirectory, configurationsFilePath);
        
        // Act
        string filePath = Path.GetFullPath(fullFilePath);
        
        // Assert
        Assert.Equal(shouldExist, File.Exists(filePath));
        if (shouldExist)
        {
            Assert.Equal(filePath, Path.GetDirectoryName(filePath)+@"\ConfigurationsFile.json");
        }
        else
        {
            Assert.False(File.Exists(filePath), "The file should not exist for an invalid path.");
        }
        
    }
    
    [Theory]
    [InlineData("ConfigurationsFile.json")]
    public void ReadConfigurationsFileContent_WhenFileExists_ThenReturnsCorrectContent(string configurationsFilePath)
    {
        // Arrange
        string testFilePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory()), configurationsFilePath);
        string expectedContent = """
                                    {
                                   "RainBot": {
                                     "enabled": true,
                                     "humidityThreshold": 70,
                                     "message": "It looks like it's about to pour down!"
                                   },
                                   "SunBot": {
                                     "enabled": true,
                                     "temperatureThreshold": 30,
                                     "message": "Wow, it's a scorcher out there!"
                                   },
                                   "SnowBot": {
                                     "enabled": false,
                                     "temperatureThreshold": 0,
                                     "message": "Brrr, it's getting chilly!"
                                   }
                                 }
                                 """.Trim();    
        File.WriteAllText(testFilePath, expectedContent);
        
        // Act
        string fileContent = ConfigurationsFileReader.ReadConfigurationsFileContent(configurationsFilePath);
        
        // Assert
        Assert.Equal(expectedContent, fileContent);
        
        // Cleanup
        File.Delete(testFilePath);
    }

    [Theory]
    [InlineData("NonExistentFile.json")]
    public void ReadConfigurationsFileContent_WhenFileDoesNotExist_ThenThrowsFileNotFoundException(
        string configurationsFilePath)
    {
        // Arrange
        string testFilePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory()), configurationsFilePath);
        
        // Act & Assert 
        Assert.Throws<FileNotFoundException>(() => ConfigurationsFileReader.ReadConfigurationsFileContent(testFilePath));
        
    }
    
}