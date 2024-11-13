using Application.Interfaces;
using Application.Services;
using Core.Entities;
using Infrastructure.Abstraction;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Application.Log;
using System.Collections.Generic;

namespace TestProject1
{
    public class CountryServiceTests
    {
        private readonly Mock<ICountryRepository> _mockRepository;
        private readonly Mock<ILoggerService<CountryService>> _mockLogger;
        private readonly CountryService _countryService;

        public CountryServiceTests()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _mockLogger = new Mock<ILoggerService<CountryService>>();
            _countryService = new CountryService(_mockRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetCountryByPhoneNumberAsync_ReturnsSuccess_WhenCountryExists()
        {
            // Arrange
            string phoneNumber = "2348033432323";
            var mockCountry = new Country
            {
                CountryCode = "234",
                Name = "Nigeria",
                CountryIso = "NG",
                CountryDetails = new List<CountryDetail>
                {
                    new CountryDetail { Operator = "MTN Nigeria", OperatorCode = "MTN NG" }
                }
            };

            _mockRepository.Setup(x => x.GetCountryByCodeAsync("234")).ReturnsAsync(mockCountry);

            // Act
            var result = await _countryService.GetCountryByPhoneNumberAsync(phoneNumber);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Country details retrieved successfully.", result.Message);
            Assert.Equal("2348033432323", result.Data.Number);
            Assert.NotNull(result.Data.Country);
            Assert.Equal("Nigeria", result.Data.Country.Name);
        }

        [Fact]
        public async Task GetCountryByPhoneNumberAsync_ReturnsNotFound_WhenCountryDoesNotExist()
        {
            // Arrange
            string phoneNumber = "2258033432323";
            _mockRepository.Setup(x => x.GetCountryByCodeAsync("225")).ReturnsAsync((Country)null);

            // Act
            var result = await _countryService.GetCountryByPhoneNumberAsync(phoneNumber);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Country not found for the provided phone number", result.Message);
        }
    }
}
